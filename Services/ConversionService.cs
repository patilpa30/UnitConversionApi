using UnitConversionApi.DTOs;
using UnitConversionApi.Services.Interfaces;


namespace UnitConversionApi.Services;

public class ConversionService
{
    private readonly IUnitConverterFactory _factory;

    public ConversionService(IUnitConverterFactory factory)
    {
        _factory = factory;
    }

    public double Convert(ConvertRequest request)
    {
        Validate(request);

        var fromUnit = request.FromUnit.Trim();
        var toUnit = request.ToUnit.Trim();

        // ✅ FIX: NO string conversion needed anymore
        var converter = _factory.GetConverter(request.Category);

        return converter.Convert(
            request.Value,
            fromUnit,
            toUnit
        );
    }

    private void Validate(ConvertRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.FromUnit) ||
            string.IsNullOrWhiteSpace(request.ToUnit))
        {
            throw new ArgumentException("FromUnit and ToUnit are required.");
        }

        if (double.IsNaN(request.Value) || double.IsInfinity(request.Value))
            throw new ArgumentException("Invalid numeric value.");
    }
}