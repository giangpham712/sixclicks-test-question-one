using System.Linq;
using SixClicksTest.ConsoleApp.Models.Abstract;
using SixClicksTest.ConsoleApp.Models.Enums;

namespace SixClicksTest.ConsoleApp.Models
{
    public class BasicSalesTax : SalesTax
    {
        private static readonly ProductType[] ExemptedProductTypes =
        {
            ProductType.Book, 
            ProductType.Food, 
            ProductType.Medical
        };
        
        public override decimal Rate => 0.1M;

        public override bool IsApplicable(Product product)
        {
            return !ExemptedProductTypes.Contains(product.Type);
        }
    }
}