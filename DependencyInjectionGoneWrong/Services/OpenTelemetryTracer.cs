namespace DependencyInjectionGoneWrong.Services;

public class OpenTelemetryTracer
{
    private readonly ActivitySource _source;

    public OpenTelemetryTracer()
    {
        _source = new ActivitySource("WeatherForecastService");
    }
    public Activity? StartActivity(string name)
    {
        return _source.StartActivity(name);
    }
}
