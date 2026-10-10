using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<ILogger, InMemoryLogger>();
services.AddTransient<Worker>();

using var provider = services.BuildServiceProvider();
var worker = provider.GetRequiredService<Worker>();
worker.DoWork();

Console.WriteLine($"Manual composition root: {ManualCompositionRoot.Run()}");

var productionWorker = new Worker(new ConsoleLogger());
productionWorker.DoWork();

foreach (var message in provider.GetRequiredService<InMemoryLogger>().Messages)
{
    Console.WriteLine(message);
}

public interface ILogger
{
    void Log(string message);
}

public sealed class InMemoryLogger : ILogger
{
    public List<string> Messages { get; } = [];

    public void Log(string message) => Messages.Add(message);
}

public sealed class Worker(ILogger logger)
{
    public void DoWork() => logger.Log("Worker completed work.");
}
