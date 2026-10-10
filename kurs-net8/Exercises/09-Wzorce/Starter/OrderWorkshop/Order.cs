namespace OrderWorkshopStarter;

public sealed class Order
{
    private readonly List<INotification> _notifications = [];
    private IOrderState _state = new AcceptedState();

    public Order(IShippingCostStrategy shippingCostStrategy, decimal amount)
    {
        ShippingCostStrategy = shippingCostStrategy;
        Amount = amount;
    }

    public IShippingCostStrategy ShippingCostStrategy { get; }
    public decimal Amount { get; private set; }
    public string Status { get; private set; } = "Accepted";

    public void AddNotification(INotification notification) => _notifications.Add(notification);

    public void Process()
    {
        Amount += ShippingCostStrategy.Calculate(Amount);
        foreach (var notification in _notifications)
        {
            notification.Send($"Order total: {Amount:0.00}");
        }

        _state.Handle(this);
    }

    public void ChangeState(IOrderState state) => _state = state;
    public void SetStatus(string status) => Status = status;
}

public interface IShippingCostStrategy
{
    decimal Calculate(decimal orderAmount);
}

public sealed class StandardShipping : IShippingCostStrategy
{
    public decimal Calculate(decimal orderAmount) => 10m;
}

public sealed class ExpressShipping : IShippingCostStrategy
{
    public decimal Calculate(decimal orderAmount) => 20m;
}

public interface INotification
{
    void Send(string message);
}

public sealed class RecordingNotification : INotification
{
    public List<string> Messages { get; } = [];
    public void Send(string message) => Messages.Add(message);
}

public interface IOrderState
{
    void Handle(Order order);
}

public sealed class AcceptedState : IOrderState
{
    public void Handle(Order order) => order.SetStatus("InProgress");
}

public sealed class ShippedState : IOrderState
{
    public void Handle(Order order) => order.SetStatus("Shipped");
}

public interface ICommand
{
    void Execute();
}

public sealed class ProcessOrderCommand(Order order) : ICommand
{
    public void Execute() => order.Process();
}
