namespace DependencyInjectionGoneWrong.Services;

public interface ICultureInfoProvider
{
    CultureInfo GetCultureInfo();
}

public class CultureInfoProvider : ICultureInfoProvider
{
    public CultureInfo GetCultureInfo()
    {
        return CultureInfo.CurrentCulture;
    }
}