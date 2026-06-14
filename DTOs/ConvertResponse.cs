namespace UnitConversionApi.DTOs;

public class ConvertResponse
{
    public double Result { get; set; }
    public string Message { get; set; } = "Conversion successful";
}