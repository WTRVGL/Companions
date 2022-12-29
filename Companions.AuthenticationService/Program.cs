using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
using Microsoft.OpenApi.Models;
using Companions.AuthenticationService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Authentication Service",
        Version = "v1",
        Description =
            $"<h2>Companions JWT Authentication Service</h2>" +
            $"<ul>" +
                $"<li>" +
                    $"<h3>" +
                        $"Requires Companions REST API to fetch User" +
                     $"</h3>" +
                $"</li>" +
             $"</ul>" 

    });

    config.EnableAnnotations();
});

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IHashPasswordService, HashPasswordService>();

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
                context.Token = context.Request.Cookies[jwtConfig.JWTHttpCookieName];
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

