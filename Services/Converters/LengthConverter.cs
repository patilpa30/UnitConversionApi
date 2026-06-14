using UnitConversionApi.Services.Interfaces;

namespace UnitConversionApi.Services.Converters;

public class LengthConverter : IUnitConverter
{
    private static readonly Dictionary<string, double> Units = new(StringComparer.OrdinalIgnoreCase)
    {
        { "mm", 0.001 },
        { "cm", 0.01 },
        { "m", 1 },
        { "meter", 1 },
        { "km", 1000 },
        { "inch", 0.0254 },
        { "foot", 0.3048 },
        { "yard", 0.9144 },
        { "mile", 1609.34 }
    };

    public double Convert(double value, string fromUnit, string toUnit)
    {
        ValidateUnits(fromUnit, toUnit);

        var trimmedFrom = fromUnit.Trim();
        var trimmedTo = toUnit.Trim();
        if (trimmedFrom.Equals(trimmedTo, StringComparison.OrdinalIgnoreCase))
        {
            return value;
        }
        // Naya handling: Category specific cross-validation with custom messages
        if (!Units.TryGetValue(trimmedFrom, out var from))
            throw new ArgumentException($"Invalid unit '{fromUnit}' for Length category. Supported units: {string.Join(", ", Units.Keys)}");

        if (!Units.TryGetValue(trimmedTo, out var to))
            throw new ArgumentException($"Invalid unit '{toUnit}' for Length category. Supported units: {string.Join(", ", Units.Keys)}");

        return (value * from) / to;
    }

    private void ValidateUnits(string fromUnit, string toUnit)
    {
        if (string.IsNullOrWhiteSpace(fromUnit) ||
            string.IsNullOrWhiteSpace(toUnit))
        {
            throw new ArgumentException("Units cannot be empty.");
        }
    }
}