public static class ManualCompositionRoot
{
    public static string Run()
    {
        // To jest ręczne wstrzykiwanie zależności: obiekty powstają w jednym
        // miejscu, a Worker nie zna sposobu tworzenia loggera.
        var logger = new InMemoryLogger();
        var worker = new Worker(logger);

        worker.DoWork();

        return logger.Messages.Single();
    }
}

public sealed class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
