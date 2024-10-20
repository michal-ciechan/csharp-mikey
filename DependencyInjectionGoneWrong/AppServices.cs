namespace DependencyInjectionGoneWrong;

public class AppServices
{
    public static TimeProvider TimeProvider { get; set; } = TimeProvider.System;
}
