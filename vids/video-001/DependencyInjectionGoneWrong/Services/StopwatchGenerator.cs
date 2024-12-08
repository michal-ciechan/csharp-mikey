namespace DependencyInjectionGoneWrong.Services;

public interface IStopwatchGenerator
{
    Stopwatch StartNew();
}

public class StopwatchGenerator : IStopwatchGenerator
{
    public Stopwatch StartNew()
    {
        throw new NotImplementedException();
    }
}