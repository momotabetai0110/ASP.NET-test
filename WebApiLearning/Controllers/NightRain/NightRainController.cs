using Microsoft.AspNetCore.Mvc;
using MyApp.Services.NightRain;
using MyApp.Models.NightRain;
namespace MyApp.Controllers.NightRain;

[Route("api/NightRain")]
[ApiController]
public class NightRainController : ControllerBase
{
    private readonly INightRainService _service;
    public NightRainController(INightRainService service){
        _service = service;
    }
    private readonly Random _random = new Random();

    [HttpPost]
    public IActionResult Post([FromBody] NightRainRequestDto dto)
    {
        var result = _service.Create(dto);
        return Ok(result);
    }

}