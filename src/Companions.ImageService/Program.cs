using Companions.ImageService;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Companions Image Upload Service",
        Version = "v1",
        Description =
        $"<h2>Upload images to a Google Cloud Storage Bucket</h2>" +
        $"<h3>Requires a valid Google Service Key</h3>"
    });

    config.EnableAnnotations();


});
builder.Services.AddSingleton<ICloudStorage, GoogleCloudStorage>();

var app = builder.Build();

//Check required configs
var serviceKeyFileLocation = app.Configuration.GetValue<string>("GoogleServiceKey");
if (!File.Exists(serviceKeyFileLocation)) throw new Exception("Google Service Key JSON missing");


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

app.UseAuthorization();

app.MapControllers();


app.Run();
