using OrderWorkshopStarter;

var order = new Order(new StandardShipping(), 100m);
var notification = new RecordingNotification();
order.AddNotification(notification);

var command = new ProcessOrderCommand(order);
command.Execute();

Console.WriteLine($"{order.Status}: {order.Amount:0.00}");
