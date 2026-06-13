using Microsoft.AspNetCore.Mvc;
using UnitConversion.Api.Models;
using UnitConversion.Api.Services;

namespace UnitConversion.Api.Controllers;

[ApiController]
[Route("api/conversions")]
public class ConversionsController : ControllerBase
{
    private readonly ConversionService _service;

    public ConversionsController(ConversionService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<ConversionResponse> Convert(
        ConversionRequest request)
    {
        var result = _service.Convert(
            request.Value,
            request.FromUnit,
            request.ToUnit);

        return Ok(new ConversionResponse
        {
            OriginalValue = request.Value,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            ConvertedValue = Math.Round(result, 6)
        });
    }

    [HttpGet("units")]
    public IActionResult GetUnits()
    {
        return Ok(_service.GetUnits());
    }
}