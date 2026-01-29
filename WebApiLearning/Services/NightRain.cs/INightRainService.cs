using MyApp.Models.NightRain;
namespace MyApp.Services.NightRain;

public interface INightRainService{
    object Create(NightRainRequestDto dto);
}