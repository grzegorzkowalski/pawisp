namespace CodeSmellsStarter;

public sealed class ProductManager
{
    public string RegisterProduct(string name, string category, decimal price, int quantity)
        => $"{name}|{category}|{price}|{quantity}";
}

public sealed class Logger
{
    public string Error(string message, DateTime timestamp)
        => $"ERROR: [{timestamp:yyyy-MM-dd HH:mm:ss}] {message}";

    public string Warning(string message, DateTime timestamp)
        => $"WARNING: [{timestamp:yyyy-MM-dd HH:mm:ss}] {message}";
}
