using UnitConversionApi.Services.Interfaces;

namespace UnitConversionApi.Services.Converters;

public class TemperatureConverter : IUnitConverter
{
    private static readonly HashSet<string> ValidUnits = new(StringComparer.OrdinalIgnoreCase)
    {
        "celsius", "fahrenheit", "kelvin"
    };

    public double Convert(double value, string fromUnit, string toUnit)
    {
        if (string.IsNullOrWhiteSpace(fromUnit) ||
            string.IsNullOrWhiteSpace(toUnit))
        {
            throw new ArgumentException("Units cannot be empty.");
        }

        var trimmedFrom = fromUnit.Trim().ToLower();
        var trimmedTo = toUnit.Trim().ToLower();
        if (trimmedFrom.Equals(trimmedTo, StringComparison.OrdinalIgnoreCase))
        {
            return value;
        }

        // Naya handling: Cross-category/garbage verification
        if (!ValidUnits.Contains(trimmedFrom))
        {
            throw new ArgumentException($"Invalid unit '{fromUnit}' for Temperature category. Supported units: Celsius, Fahrenheit, Kelvin");
        }

        if (!ValidUnits.Contains(trimmedTo))
        {
            throw new ArgumentException($"Invalid unit '{toUnit}' for Temperature category. Supported units: Celsius, Fahrenheit, Kelvin");
        }

        // Identity handling: Jab from aur to exact same ho tab crash na kare
        if (trimmedFrom == trimmedTo)
        {
            return value;
        }

        // Aapka original exact math setup
        return (trimmedFrom, trimmedTo) switch
        {
            ("celsius", "fahrenheit") => (value * 9 / 5) + 32,
            ("fahrenheit", "celsius") => (value - 32) * 5 / 9,
            ("celsius", "kelvin")     => value + 273.15,
            ("kelvin", "celsius")     => value - 273.15,
            ("fahrenheit", "kelvin")  => ((value - 32) * 5 / 9) + 273.15,
            ("kelvin", "fahrenheit")  => ((value - 273.15) * 9 / 5) + 32,
            _ => throw new ArgumentException($"Invalid temperature conversion: {fromUnit} → {toUnit}")
        };
    }
}