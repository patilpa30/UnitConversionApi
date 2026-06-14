using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.DTOs;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly ConversionService _conversionService;

    public ConversionController(ConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpPost]
    public ActionResult<ConvertResponse> Convert([FromBody] ConvertRequest request)
    {
        var result = _conversionService.Convert(request);

        return Ok(new ConvertResponse
        {
            Result = Math.Round(result, 4)
        });
    }
}