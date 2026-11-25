using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
namespace DiscountTraining.DiscountApi.Tests;

[TestFixture]
public class DiscountApiTests
{
    private WebApplicationFactory<Program> _factory = null!;
    private HttpClient _client = null!;
    [SetUp] public void SetUp() { _factory = new WebApplicationFactory<Program>(); _client = _factory.CreateClient(); }
    [TearDown] public void TearDown() { _client.Dispose(); _factory.Dispose(); }
    [Test]
    public async Task CalculateDiscount_ForAmount500_Returns20PercentDiscount()
    {
        var response = await _client.PostAsJsonAsync("/api/discounts/calculate", new { orderAmount = 500m });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadFromJsonAsync<DiscountResponse>();
        Assert.That(body, Is.Not.Null);
        Assert.That(body!.DiscountRate, Is.EqualTo(0.20m));
        Assert.That(body.DiscountAmount, Is.EqualTo(100m));
        Assert.That(body.FinalAmount, Is.EqualTo(400m));
    }
    [Test]
    public async Task CalculateDiscount_ForNegativeAmount_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/api/discounts/calculate", new { orderAmount = -1m });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    private record DiscountResponse(decimal OrderAmount, decimal DiscountRate, decimal DiscountAmount, decimal FinalAmount);
}
