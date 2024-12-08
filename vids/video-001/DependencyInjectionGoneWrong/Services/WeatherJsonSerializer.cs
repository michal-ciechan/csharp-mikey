namespace DependencyInjectionGoneWrong.Services;

public class WeatherJsonSerializer
{
    public string Serialize<T>(T forecasts)
    {
        return JsonSerializer.Serialize(forecasts);
    }
}