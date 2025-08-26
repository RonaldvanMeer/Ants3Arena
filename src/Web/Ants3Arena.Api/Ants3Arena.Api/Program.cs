using Ants3Arena.Api.Business;
using Ants3Arena.Api.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessDependencies(
    builder.Configuration,
    Assembly.GetAssembly(typeof(DataDependenciesSetup))!,
    Assembly.GetAssembly(typeof(BusinessDependenciesSetup))!);
builder.Services.AddControllers();

builder.Services
    .AddOpenApiDocument(options =>
    {
        options.DocumentName = "v1";
        options.ApiGroupNames = ["v1"];
    });

builder.Services
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
