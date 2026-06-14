using UnitConversionApi.Services.Interfaces;

namespace UnitConversionApi.Services.Converters;

public class WeightConverter : IUnitConverter
{
    private static readonly Dictionary<string, double> Units = new(StringComparer.OrdinalIgnoreCase)
    {
        { "mg", 0.000001 },
        { "g", 1 },
        { "gram", 1 },
        { "kg", 1000 },
        { "ounce", 28.3495 },
        { "pound", 453.592 }
    };

    public double Convert(double value, string fromUnit, string toUnit)
    {
        if (value < 0)
            throw new ArgumentException("Weight cannot be negative.");

        ValidateUnits(fromUnit, toUnit);

        var trimmedFrom = fromUnit.Trim();
        var trimmedTo = toUnit.Trim();
        if (trimmedFrom.Equals(trimmedTo, StringComparison.OrdinalIgnoreCase))
        {
            return value;
        }
        // Naya handling: Strict cross-category checks keeping try-get safe
        if (!Units.TryGetValue(trimmedFrom, out var from))
            throw new ArgumentException($"Invalid unit '{fromUnit}' for Weight category. Supported units: {string.Join(", ", Units.Keys)}");

        if (!Units.TryGetValue(trimmedTo, out var to))
            throw new ArgumentException($"Invalid unit '{toUnit}' for Weight category. Supported units: {string.Join(", ", Units.Keys)}");

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