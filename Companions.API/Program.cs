using Companions.API.Models;
using Companions.API.Mapper;
using Companions.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Companions.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

JWTConfiguration jwtConfig = builder.Configuration.GetSection("JWT").Get<JWTConfiguration>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            IssuerSigningKey =
                new SymmetricSecurityKey(Convert.FromBase64String(jwtConfig.Secret)),
            ValidateIssuerSigningKey = true
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                //Extract Token from HTTPOnly Cookie
                //context.Token = context.Request.Cookies[jwtConfig.JWTHttpCookieName];
                //return Task.CompletedTask;
                context.Token = context.Request.Headers.Authorization;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


string swaggerFileLinkAuthServiceURL = builder.Configuration.GetValue<string>("CompanionsAuthenticationServiceURL") + "/swagger/index.html";
string swaggerFileLinkImageServiceURL = builder.Configuration.GetValue<string>("CompanionsImageServiceURL") + "/swagger/index.html";

builder.Services.AddSwaggerGen(config =>
{
    //Swagger Service Documentation
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Companions REST Api",
        Version = "v1",
        Description =
            $"<h2>Main API to peform Database calls</h2>" +
            $"<ul>" +
                $"<li>" +
                    $"<h3>" +
                        $"Requires live Db connection" +
                     $"</h3>" +
                $"</li>" +
                $"<li>" +
                    $"<h3>" +
                        $"JWT token needs to be present in the Header as Authorization" +
                     $"</h3>" +
                $"</li>" +
                $"<li>" +
                    $"<h3>" +
                        $"Companion Services:" +
                     $"</h3>" +
                     $"<ul>" +
                       $"<li>" +
                           $"<h3>" +
                               $"<a href=\"{swaggerFileLinkAuthServiceURL}\">Authentication Service</a>" +
                            $"</h3>" +
                       $"</li>" +
                       $"<li>" +
                           $"<h3>" +
                               $"<a href=\"{swaggerFileLinkImageServiceURL}\">Image Service</a>" +
                            $"</h3>" +
                       $"</li>" +
                    $"</ul>" +
                $"</li>" +
            $"</ul>"
    });

    config.EnableAnnotations();

    //Swagger Bearer Auth Scheme
    config.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = $"Supply a valid JWT containing an \"id\" claim",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer",

    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddTransient<IBuddyService, BuddyService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

//Seed db
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    //Delete db
    //context.Database.EnsureDeleted();
    context.Database.Migrate();
    DbInitializer.InitializeDb(context);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
