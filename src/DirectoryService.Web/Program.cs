using DirectoryService.Infrastructure;
using DirectoryService.Web;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgram();

bool isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddInfrastructure(builder.Configuration, isDevelopment);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();