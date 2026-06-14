using UnitConversionApi.Services.Interfaces;
using UnitConversionApi.Services.Factory;
using UnitConversionApi.Services;
using UnitConversionApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI (Swagger style minimal API)
builder.Services.AddOpenApi();

// Controllers + Enum fix
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Dependency Injection
builder.Services.AddScoped<IUnitConverterFactory, UnitConverterFactory>();
builder.Services.AddScoped<ConversionService>();

var app = builder.Build();

// OpenAPI only in dev
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Exception middleware must be at the VERY top of the pipeline to catch all downstream errors
app.UseMiddleware<UnitConversionApi.Middleware.ExceptionMiddleware>();

app.UseAuthorization(); // If you ever add authorization later

app.MapControllers();

app.MapGet("/", () => "API Running");

app.Run();