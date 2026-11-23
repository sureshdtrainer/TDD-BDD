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
}
