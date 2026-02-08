using Microsoft.AspNetCore.Mvc;
using MyApp.Services.NightRain;
using MyApp.Models.NightRain;
namespace MyApp.Controllers.NightRain;

[Route("api/NightRain")]
[ApiController]
public class NightRainController(INightRainService service) : ControllerBase
{
    private readonly Random _random = new Random();

    [HttpPost]
    public IActionResult Post([FromBody] NightRainRequestDto dto)
    {
        var result = service.Create(dto);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = service.Get();
        return Ok(result);
    }

}