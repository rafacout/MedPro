using MedPro.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MedPro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly OpeningTimeOption _openingTimeOption;
    public TestController(IOptions<OpeningTimeOption> openingTimeOption)
    {
        _openingTimeOption = openingTimeOption.Value;
    }

    [HttpGet("{id}")]
    public IActionResult GetStatus(int id)
    {
        return Content($"Get success: {id}");
    }

    [HttpGet]
    public IActionResult GetOpeningTime()
    {
        return Content($"Start at: {_openingTimeOption.StartAt}");
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast weather)
    {
        var value = new
        {
            id = 1,
            summary = weather.Summary,
            temperature = weather.TemperatureC
        };
        
        return CreatedAtAction(nameof(Post), value);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] WeatherForecast weather)
    {
        var value = new
        {
            id,
            summary = weather.Summary,
            temperature = weather.TemperatureC
        };

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}