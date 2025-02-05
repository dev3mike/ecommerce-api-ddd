using ECM.Application;
using ECM.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddControllers();

// Add Infrastructure Services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add Application Services
builder.Services.AddApplicationServices(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "E-Commerce API",
        Version = "v1",
        Description = "A DDD-based E-Commerce API"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => { c.RouteTemplate = "api-docs/{documentName}/swagger.json"; });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/api-docs/v1/swagger.json", "E-Commerce API v1");
        c.RoutePrefix = "api-docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();