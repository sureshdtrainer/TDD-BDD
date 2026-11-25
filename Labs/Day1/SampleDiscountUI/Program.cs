var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/order", () => Results.Redirect("/"));

app.MapPost("/api/discounts/calculate", (DiscountRequest request) =>
{
    if (request.OrderAmount < 0)
        return Results.BadRequest(new { error = "Order amount must be zero or greater." });

    const decimal discountRate = 0.10m;
    var discountAmount = Math.Round(request.OrderAmount * discountRate, 2, MidpointRounding.AwayFromZero);
    var payableAmount = request.OrderAmount - discountAmount;

    return Results.Ok(new DiscountResponse(
        request.OrderAmount, discountRate, discountAmount, payableAmount));
});

app.Run();

public sealed record DiscountRequest(decimal OrderAmount);
public sealed record DiscountResponse(
    decimal OrderAmount,
    decimal DiscountRate,
    decimal DiscountAmount,
    decimal PayableAmount);
