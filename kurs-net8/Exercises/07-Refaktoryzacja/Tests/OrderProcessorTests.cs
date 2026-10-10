using RefactoringStarter;

public sealed class OrderProcessorTests
{
    [Fact]
    public void Accepted_standard_order_moves_to_in_progress()
    {
        var processor = new OrderProcessor();

        var result = processor.Process("Standard", 100m, "Accepted");

        Assert.Equal("Standard:110:InProgress", result);
    }
}
