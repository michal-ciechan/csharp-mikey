namespace DependencyInjectionGoneWrong;

public class AppServices
{
    public static AppServicesInstance Instance { get; set; } = new AppServicesInstance();
    
    public static TimeProvider TimeProvider => Instance.TimeProvider;
}

public class AppServicesInstance
{
    public virtual TimeProvider TimeProvider { get; set; } = TimeProvider.System;
}
