using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m; // 18% tax
        }
    }
}
