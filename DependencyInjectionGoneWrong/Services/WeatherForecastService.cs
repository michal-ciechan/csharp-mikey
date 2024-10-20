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
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly OpenTelemetryTracer _tracer;
    private readonly TimeProvider _timeProvider;
    private readonly IStopwatchGenerator _stopwatchGenerator;
    private readonly TaskFactory _taskFactory;
    private readonly ICultureInfoProvider _cultureInfoProvider;
    private readonly IFileSystem _fileSystem;
    private readonly WeatherJsonSerializer _jsonSerializer;
    private readonly ConfigOptions _config;
    private readonly HttpClient _httpClient;
    private readonly ICityNameProvider _cityNameProvider;
    private readonly IWeatherForecastCalculator _weatherForecastCalculator;

    public WeatherForecastService(
        ILogger<WeatherForecastService> logger,
        OpenTelemetryTracer tracer,
        TimeProvider timeProvider,
        IStopwatchGenerator stopwatchGenerator,
        TaskFactory taskFactory,
        ICultureInfoProvider cultureInfoProvider,
        IFileSystem fileSystem,
        WeatherJsonSerializer jsonSerializer,
        IOptions<ConfigOptions> configOptions,
        HttpClient httpClient,
        ICityNameProvider cityNameProvider,
        IWeatherForecastCalculator weatherForecastCalculator
    )
    {
        _logger = logger;
        _tracer = tracer;
        _timeProvider = timeProvider;
        _stopwatchGenerator = stopwatchGenerator;
        _taskFactory = taskFactory;
        _cultureInfoProvider = cultureInfoProvider;
        _fileSystem = fileSystem;
        _jsonSerializer = jsonSerializer;
        _config = configOptions.Value;
        _httpClient = httpClient;
        _cityNameProvider = cityNameProvider;
        _weatherForecastCalculator = weatherForecastCalculator;
    }
    
    public async Task<WeatherForecast[]> GenerateWeatherForecast(int cityId)
    {
        _tracer.StartActivity("GenerateWeatherForecast");
        
        _logger.LogInformation("Generating weather forecast");
        
        var stopwatch = _stopwatchGenerator.StartNew();
        var cityName = _cityNameProvider.GetCityName(cityId);
        var cultureInfo = _cultureInfoProvider.GetCultureInfo();

        // Fetch Calculated and Remote Weather Forecasts
        var calculatedForecasts = await _taskFactory.StartNew(
            () => _weatherForecastCalculator.GetWeather(cityId)
        );
        
        var remoteForecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>(
            $"{_config.RemoteServiceUrl}/weather?cityId={cityId}"
        );
        
        // Combine
        var result = calculatedForecasts.UnionBy(remoteForecasts!, x => x.Date).ToArray();
        
        // Save
        var filePath = _fileSystem.Path.Combine(_config.OutputPath, $"{cityId}.json");
        await _fileSystem.File.WriteAllTextAsync(filePath, _jsonSerializer.Serialize(result));

        _logger.LogInformation(
            "Weather forecast for {City}[{CityId}] generated in {ElapsedMilliseconds}ms at {Time}",
            cityName,
            cityId,
            stopwatch.ElapsedMilliseconds.ToString(cultureInfo),
            _timeProvider.GetUtcNow().ToString(cultureInfo)
        );
        
        return result;
    }
}
