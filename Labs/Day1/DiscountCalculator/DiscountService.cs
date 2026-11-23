namespace DiscountCalculator;

public class DiscountService
{
    public decimal CalculateFinalAmount(decimal amount)
    {
        if(amount >= 500m)
        {
            return amount * 0.8m; // Apply 20% discount
        }

        if (amount>= 100m)
        {
            return amount * 0.9m; // Apply 10% discount
        }
        return amount; // No discount
    }

}
