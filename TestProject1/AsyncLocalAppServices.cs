using DependencyInjectionGoneWrong;

namespace TestProject1;

public class AsyncLocalAppServices : AppServicesInstance
{
    private static readonly AsyncLocal<TimeProvider> _timeProvider = new();
    public override TimeProvider TimeProvider
    {
        get => _timeProvider.Value ?? throw new Exception("TimeProvider not initialised");
        set => _timeProvider.Value = value;
    }
}
