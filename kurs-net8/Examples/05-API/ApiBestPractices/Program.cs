var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseExceptionHandler();

var orders = new Dictionary<Guid, OrderResponse>();

app.MapGet("/api/orders/{id:guid}", (Guid id) =>
    orders.TryGetValue(id, out var order)
        ? Results.Ok(order)
        : Results.NotFound());

app.MapPost("/api/orders", (CreateOrderRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Customer))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            [nameof(request.Customer)] = ["Customer is required."]
        });
    }

    if (request.Total <= 0)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            [nameof(request.Total)] = ["Total must be greater than zero."]
        });
    }

    var response = new OrderResponse(Guid.NewGuid(), request.Customer, request.Total, "Accepted");
    orders.Add(response.Id, response);
    return Results.Created($"/api/orders/{response.Id}", response);
});

app.Run();

public sealed record CreateOrderRequest(string? Customer, decimal Total);
public sealed record OrderResponse(Guid Id, string Customer, decimal Total, string Status);
