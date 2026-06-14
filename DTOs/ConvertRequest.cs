using System.ComponentModel.DataAnnotations;
using UnitConversionApi.Models;

namespace UnitConversionApi.DTOs;

public class ConvertRequest
{
    [Required]
    public ConversionCategory Category { get; set; }

    [Required]
    public string FromUnit { get; set; } = string.Empty;

    [Required]
    public string ToUnit { get; set; } = string.Empty;

    [Required]
    public double Value { get; set; }
}