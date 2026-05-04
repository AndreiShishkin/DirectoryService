using DirectoryService.Domain.Departments;
using DirectoryService.Domain.ValueObjects;
using DirectoryService.Infrastructure;
using Microsoft.OpenApi;
using Path = System.IO.Path;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Directory Service API",
            Contact = new OpenApiContact { Name = "Shishkin Andrey", },
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

app.MapPost("/department", (DirectoryServiceDbContext dbContext) =>
{
    var departmentName = DepartmentName.Create("Test").Value;
    var identifier = Identifier.Create("test").Value;
    var path = DirectoryService.Domain.ValueObjects.Path.Create("test").Value;
    dbContext.Add(
        Department.Create(
            departmentName,
            identifier,
            null,
            Array.Empty<Guid>(),
            Array.Empty<Guid>(),
            path,
            0).Value);
    dbContext.SaveChanges();
});

app.MapGet("/test", () => "Hello World!");

app.Run();