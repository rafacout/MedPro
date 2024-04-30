using Microsoft.AspNetCore.Mvc;

namespace MedPro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet("{id}")]
    public IActionResult GetStatus(int id)
    {
        return Content($"Get success: {id}");
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