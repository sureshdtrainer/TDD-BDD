namespace DiscountCalculator.Tests;

[TestFixture]
public class DiscountServiceTests
{
    private DiscountService _service;
    [SetUp]
    public void Setup()
    {
         _service = new DiscountService();
    }

    [Test]
    public void CalculateFinalAmount_BelowThreshold_NoDiscount()    
    {

        var result = _service.CalculateFinalAmount(50m);
        Assert.That(result, Is.EqualTo(50m));
    }

    [Test]
    public void CalculateFinalAmount_EligibleForTenPercentDiscount()
    {
        
        var result = _service.CalculateFinalAmount(200m);
        Assert.That(result, Is.EqualTo(180m));
    }

    [Test]
    public void CalculateFinalAmount_EligibleForTwentyPercentDiscount()
    {
        var result = _service.CalculateFinalAmount(600m);
        Assert.That(result, Is.EqualTo(480));
    }

    [TestCase(99.99, 99.99)]
    [TestCase(100, 90)]
    [TestCase(500, 400)]
    [TestCase(700, 560)]
    [Test]
    public void CalculateFinalAmount_ReturnsExpectedValue(decimal amount, decimal expected)
    {
        var result = _service.CalculateFinalAmount(amount);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CalculateFinalAmount_NegativeAmount_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _service.CalculateFinalAmount(-50m));
    }
}
