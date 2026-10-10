namespace RefactoringStarter;

public sealed class OrderProcessor
{
    public string Process(string type, decimal amount, string status)
    {
        var shipping = type == "Express" ? 20m : 10m;
        var total = amount + shipping;

        Console.WriteLine("Sending e-mail...");
        Console.WriteLine("Sending SMS...");

        var nextStatus = status == "Accepted" ? "InProgress" : "Shipped";
        return $"{type}:{total}:{nextStatus}";
    }
}
