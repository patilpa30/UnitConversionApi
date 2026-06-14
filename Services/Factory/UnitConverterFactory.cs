using UnitConversionApi.Services.Interfaces;
using UnitConversionApi.Services.Converters;
using UnitConversionApi.Models;
namespace UnitConversionApi.Services.Factory;

public class UnitConverterFactory : IUnitConverterFactory
{
    private readonly Dictionary<string, IUnitConverter> _converters;

    public UnitConverterFactory()
    {
        // Single instance reuse (stateless converters)
        _converters = new Dictionary<string, IUnitConverter>(StringComparer.OrdinalIgnoreCase)
        {
            { "length", new LengthConverter() },
            { "weight", new WeightConverter() },
            { "temperature", new TemperatureConverter() }
        };
    }

    public IUnitConverter GetConverter(ConversionCategory category)
{
    return category switch
    {
        ConversionCategory.Length => _converters["length"],
        ConversionCategory.Weight => _converters["weight"],
        ConversionCategory.Temperature => _converters["temperature"],
        _ => throw new ArgumentException("Unsupported category")
    };
}
}