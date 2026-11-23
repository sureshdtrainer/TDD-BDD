using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal amount);
    }
}
