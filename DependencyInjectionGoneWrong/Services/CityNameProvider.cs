namespace DependencyInjectionGoneWrong.Services;

public interface ICityNameProvider
{
    string GetCityName(int cityId);
}

public class CityNameProvider : ICityNameProvider
{
    public string GetCityName(int cityId)
    {
        throw new NotImplementedException();
    }
}