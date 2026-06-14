using UnitConversionApi.Models;

namespace UnitConversionApi.Services.Interfaces;

public interface IUnitConverterFactory
{
    IUnitConverter GetConverter(ConversionCategory category);
}