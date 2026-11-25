using DiscountTraining.DiscountEngine;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DiscountCalculator>();
builder.Services.AddSingleton<DiscountService>();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
var app = builder.Build();
app.MapGet("/", () => Results.Content(@"<!doctype html><html lang='en'><head><meta charset='utf-8'><title>Order Discount Calculator</title></head><body><h1>Order Discount Calculator</h1><label for='amount'>Order amount</label><input id='amount' type='number' min='0' step='0.01' value='100'/><button id='calculate'>Calculate discount</button><p id='result' aria-live='polite'></p><script>document.querySelector('#calculate').addEventListener('click', async () => { const orderAmount = Number(document.querySelector('#amount').value); const response = await fetch('/api/discounts/calculate', { method:'POST', headers:{'Content-Type':'application/json'}, body:JSON.stringify({orderAmount}) }); const result = document.querySelector('#result'); if (!response.ok) { result.textContent='Invalid order amount'; return; } const data = await response.json(); result.textContent = `Discount: ${data.discountAmount.toFixed(2)} | Final: ${data.finalAmount.toFixed(2)}`; });</script></body></html>", "text/html"));
app.MapPost("/api/discounts/calculate", (DiscountRequest request, DiscountService service, DiscountCalculator calculator) =>
{
    if (request.OrderAmount < 0) return Results.BadRequest(new { message = "Order amount cannot be negative." });
    var rate = calculator.GetDiscountRate(request.OrderAmount);
    var discount = service.CalculateDiscount(request.OrderAmount);
    var finalAmount = decimal.Round(request.OrderAmount - discount, 2, MidpointRounding.AwayFromZero);
    return Results.Ok(new DiscountResponse(request.OrderAmount, rate, discount, finalAmount));
});
app.Run();
public record DiscountRequest(decimal OrderAmount);
public record DiscountResponse(decimal OrderAmount, decimal DiscountRate, decimal DiscountAmount, decimal FinalAmount);
public partial class Program { }
