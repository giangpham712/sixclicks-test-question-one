using System.Collections.Generic;
using System.Linq;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Abstract;

namespace SixClicksTest.ConsoleApp.Services
{
    public class SalesTaxCalculator : ITaxCalculator
    {
        private readonly List<SalesTax> _taxes;

        public SalesTaxCalculator()
        {
            _taxes = new List<SalesTax>();
        }

        public void RegisterSalesTax(SalesTax tax)
        {
            _taxes.Add(tax);
        }

        public decimal Calculate(CartItem item)
        {
            return _taxes.Sum(tax => item.Quantity * tax.Calculate(item.Product));
        }
    }
}