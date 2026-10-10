namespace CodeSmellsStarter;

public sealed class OrderProcessor
{
    public string Process(string customer, string country, string payment, decimal total, int items)
    {
        if (string.IsNullOrWhiteSpace(customer) || total <= 0 || items <= 0)
        {
            return "invalid";
        }

        var discount = country == "PL" ? total * 0.05m : 0;
        if (payment == "PREPAID")
        {
            discount += total * 0.02m;
        }

        var finalTotal = total - discount;
        Console.WriteLine($"Order for {customer}: {finalTotal:0.00}");
        return finalTotal.ToString("0.00");
    }
}

public sealed class CustomerDirectory
{
    private readonly Dictionary<int, string> _customers = new() { [1] = "Ada" };

    public string? FindName(int id) => _customers.TryGetValue(id, out var name) ? name : null;

    public bool IsPreferred(int id)
        => FindName(id) != null && (_customers[id].StartsWith("A") || _customers[id].StartsWith("M"));
}

public sealed class StockItem
{
    public string Sku { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public sealed class NotificationSender
{
    public string Send(string channel, string recipient, string message)
    {
        return channel switch
        {
            "email" => $"email:{recipient}:{message}",
            "sms" => $"sms:{recipient}:{message}",
            _ => "unsupported"
        };
    }
}

public sealed class LegacyOrderApplication
{
    public string Create(string customer, decimal total)
    {
        var id = Guid.NewGuid();
        var result = $"{id}:{customer}:{total:0.00}";
        Console.WriteLine(result);
        Console.WriteLine("notification sent");
        return result;
    }
}
