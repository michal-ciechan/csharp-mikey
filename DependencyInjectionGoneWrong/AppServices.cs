namespace DependencyInjectionGoneWrong;

public class AppServices
{
    public static ActivitySource Tracing { get; set; } = new ("DependencyInjectionGoneWrong");
    public static CityNameProvider CityNameProvider { get; set; } = new ();
    public static ConfigOptions Config  { get; set; } = new ();
    public static HttpClient HttpClient { get; set; } = new();
    public static TimeProvider Time { get; set; } = TimeProvider.System;
}
