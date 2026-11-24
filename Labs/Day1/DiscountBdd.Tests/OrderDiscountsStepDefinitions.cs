using DiscountCalculator;
using NUnit.Framework;
using Reqnroll;

namespace DiscountBdd.Tests;

[Binding]
public class OrderDiscountsStepDefinitions
{
    private decimal _orderAmount;
    private decimal _finalAmount;

    private readonly DiscountService _discountService = new();

    [Given(@"an order amount of (.*)")]
    public void GivenAnOrderAmountof(decimal amount)
    {
        _orderAmount = amount;
    }

    [When(@"the final amount is calculated")]
    public void WhenTheFinalAmountISCalculated()
    {
        _finalAmount = _discountService.CalculateFinalAmount(_orderAmount);
    }

    [Then(@"the final amount should be (.*)")]
    public void ThenTheFinalAmountShouldBe(decimal expectedAmount)
    {
        Assert.That(_finalAmount, Is.EqualTo(expectedAmount));
    }
    
}
