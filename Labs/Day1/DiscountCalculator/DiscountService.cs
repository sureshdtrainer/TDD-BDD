namespace DiscountCalculator;

public class DiscountService
{
    public decimal CalculateFinalAmount(decimal amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative.");
        }

        var discountRate = GetDiscountRate(amount);
        var discounted_amount = (amount * discountRate);
        var final_amount = amount - discounted_amount;//Fixed the bug induced during Refactoring
        return decimal.Round(final_amount, 2, MidpointRounding.AwayFromZero); // Round to 2 decimal places
    }

    private decimal GetDiscountRate(decimal amount)
    {
        if (amount >= 500m)
        {
            return 0.2m; // 20% discount
        }
        if (amount >= 100m)
        {
            return 0.1m; // 10% discount
        }
        return 0m; // No discount
    }

}
