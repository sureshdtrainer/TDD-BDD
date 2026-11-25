namespace DiscountTraining.DiscountEngine;

public class CheckoutService
{
    private readonly DiscountService _discountService;
    private readonly ITaxCalculator _taxCalculator;
    public CheckoutService(DiscountService discountService, ITaxCalculator taxCalculator)
    { _discountService = discountService; _taxCalculator = taxCalculator; }
    public decimal CalculateFinalAmount(decimal orderAmount)
    {
        if (orderAmount < 0) throw new ArgumentOutOfRangeException(nameof(orderAmount), "Order amount cannot be negative.");
        var discount = _discountService.CalculateDiscount(orderAmount);
        var taxableAmount = orderAmount - discount;
        var tax = _taxCalculator.CalculateTax(taxableAmount);
        return decimal.Round(taxableAmount + tax, 2, MidpointRounding.AwayFromZero);
    }
}
