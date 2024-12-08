using DependencyInjectionGoneWrong;
using Microsoft.Extensions.Time.Testing;

namespace TestProject1;

[Parallelizable(ParallelScope.All)]
public class FakeTimeProviderTests
{
    [Test]
    public async Task Test1()
    {
        var localProvider = new FakeTimeProvider();
        AppServices.Instance = new AsyncLocalAppServices()
        {
            TimeProvider = localProvider
        };

        for (int i = 0; i < 30; i++)
        {
            localProvider.Advance(TimeSpan.FromSeconds(1));
            
            var singletonTime = AppServices.TimeProvider.GetUtcNow();
            var localTime = localProvider.GetUtcNow();
            
            Console.WriteLine(singletonTime.Second + " vs " + localTime.Second);

            Assert.That(singletonTime, Is.EqualTo(localTime));

            await Task.Delay(10);
        }
    }

    [Test]
    public async Task Test2()
    {
        var localProvider = new FakeTimeProvider();
        AppServices.Instance = new AsyncLocalAppServices
        {
            TimeProvider = localProvider
        };
        
        for (int i = 0; i < 30; i++)
        {
            localProvider.Advance(TimeSpan.FromSeconds(1));
            
            var singletonTime = AppServices.TimeProvider.GetUtcNow();
            var localTime = localProvider.GetUtcNow();
            
            Console.WriteLine(singletonTime.Second + " vs " + localTime.Second);

            Assert.That(singletonTime, Is.EqualTo(localTime));

            await Task.Delay(10);
        }
    }
    
    [Test]
    public async Task Test3()
    {
        var localProvider = new FakeTimeProvider();
        AppServices.Instance = new AsyncLocalAppServices
        {
            TimeProvider = localProvider
        };
        
        for (int i = 0; i < 30; i++)
        {
            localProvider.Advance(TimeSpan.FromSeconds(1));
            
            var singletonTime = AppServices.TimeProvider.GetUtcNow();
            var localTime = localProvider.GetUtcNow();
            
            Console.WriteLine(singletonTime.Second + " vs " + localTime.Second);

            Assert.That(singletonTime, Is.EqualTo(localTime));

            await Task.Delay(10);
        }
    }
}
