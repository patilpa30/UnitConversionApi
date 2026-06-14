namespace UnitConversionApi.Services.Interfaces;

public interface IUnitConverter
{
    double Convert(double value, string fromUnit, string toUnit);
}