public sealed class WorkerTests
{
    [Fact]
    public void Worker_uses_injected_logger()
    {
        var logger = new TestLogger();
        var worker = new Worker(logger);

        worker.DoWork();

        Assert.Equal(["Worker completed work."], logger.Messages);
    }

    private sealed class TestLogger : ILogger
    {
        public List<string> Messages { get; } = [];

        public void Log(string message) => Messages.Add(message);
    }
}
