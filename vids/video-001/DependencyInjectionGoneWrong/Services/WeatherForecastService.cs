namespace DependencyInjectionGoneWrong.Services;

/// <summary>
/// 1. Fetches weather forecast for a city from a remote service
/// 2. Calculate weather forecast for a city based on local data
/// 3. Combines the two
/// 4. Saves the combined forecast to a file
/// 5. Returns it
/// </summary>
public class WeatherForecastService
{
    private static readonly Log Logger = LogManager.GetLogger(typeof(WeatherForecastService));
    private readonly IWeatherForecastCalculator _weatherForecastCalculator;

    public WeatherForecastService(
        IWeatherForecastCalculator weatherForecastCalculator
    )
    {
        _weatherForecastCalculator = weatherForecastCalculator;
    }
    
    public async Task<WeatherForecast[]> GenerateWeatherForecast(int cityId)
    {
        AppServices.Tracing.StartActivity();
        
        Logger.Info("Generating weather forecast");
        
        var stopwatch = Stopwatch.StartNew();

        // Fetch Calculated and Remote Weather Forecasts
        var calculatedForecasts = await Task.Run(() => _weatherForecastCalculator.GetWeather(cityId));
        
        var remoteForecasts = await AppServices.HttpClient.GetFromJsonAsync<WeatherForecast[]>(
            $"{AppServices.Config.RemoteServiceUrl}/weather?cityId={cityId}"
        );
        
        // Combine
        var result = calculatedForecasts.UnionBy(remoteForecasts!, x => x.Date).ToArray();
        
        // Save
        var filePath = Path.Combine(AppServices.Config.OutputPath, $"{cityId}.json");
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(result));

        var elapsedMs = stopwatch.ElapsedMilliseconds;
        var cityName = AppServices.CityNameProvider.GetCityName(cityId);
        
        Logger.Info(
            $"Weather forecast for {cityName}[{cityId}] generated in {elapsedMs}ms at {AppServices.Time.GetUtcNow()}"
        );
        
        return result;
    }
}
