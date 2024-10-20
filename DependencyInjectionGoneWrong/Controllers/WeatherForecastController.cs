namespace DependencyInjectionGoneWrong.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{cityId}", Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get(
        [FromRoute] int cityId,
        [FromServices] WeatherForecastService weatherForecastService
    )
    {
        return await weatherForecastService.GenerateWeatherForecast(cityId);
    }
}