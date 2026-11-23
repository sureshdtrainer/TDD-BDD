using Moq;

namespace DiscountCalculator.Tests;

[TestFixture]
public class CheckoutServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetTotal_AddTaxToAmount()
    {
        //Create a mock of ITaxCalculator
        var taxMock = new Mock<ITaxCalculator>();

        //Setup the mock to return a specific value when CalculateTax is called
        taxMock
            .Setup(x => x.CalculateTax(100m))
            .Returns(18m); // 18% of 100 is 18

        //Create an instance of CheckoutService with the mock
        var checkoutService = new CheckoutService(taxMock.Object);

        //Act
        var result = checkoutService.GetTotal(100m);

        Assert.That(result, Is.EqualTo(118m)); // 100 + 18 = 118
    }



}
