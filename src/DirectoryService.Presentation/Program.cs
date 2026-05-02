using DirectoryService.Infrastructure;
using Microsoft.OpenApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Directory Service API",
        Contact = new OpenApiContact
        {
            Name = "Shishkin Andrey",
        },
    });
});

builder.Services.AddOpenApi();

bool isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddInfrastructure(builder.Configuration, isDevelopment);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/test", () => "Hello World!");

app.Run();
