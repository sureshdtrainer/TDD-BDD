namespace DiscountTraining.DiscountEngine;

public class DiscountCalculator
{
    public decimal GetDiscountRate(decimal orderAmount)
    {
        if (orderAmount < 0) throw new ArgumentOutOfRangeException(nameof(orderAmount), "Order amount cannot be negative.");
        if (orderAmount < 100m) return 0m;
        if (orderAmount < 500m) return 0.10m;
        return 0.20m;
    }
}
