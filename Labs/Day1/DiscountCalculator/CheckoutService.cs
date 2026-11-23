using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public class CheckoutService
    {
        private readonly ITaxCalculator _taxCalculator;

        public CheckoutService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal GetTotal(decimal amount)
        {
            if(amount<0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            return amount + _taxCalculator.CalculateTax(amount);
        }
    }
}
