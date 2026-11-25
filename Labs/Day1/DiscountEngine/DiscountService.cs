namespace DiscountTraining.DiscountEngine;

public class DiscountService
{
    private readonly DiscountCalculator _discountCalculator;
    public DiscountService(DiscountCalculator discountCalculator) => _discountCalculator = discountCalculator;
    public decimal CalculateDiscount(decimal orderAmount)
    {
        var rate = _discountCalculator.GetDiscountRate(orderAmount);
        return decimal.Round(orderAmount * rate, 2, MidpointRounding.AwayFromZero);
    }
}
