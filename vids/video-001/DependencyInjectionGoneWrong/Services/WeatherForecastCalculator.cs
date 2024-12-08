namespace DependencyInjectionGoneWrong.Services;

public interface IWeatherForecastCalculator
{
    WeatherForecast[] GetWeather(int cityId);
}

public class WeatherForecastCalculator : IWeatherForecastCalculator
{
    public WeatherForecast[] GetWeather(int cityId)
    {
        throw new NotImplementedException();
    }
}