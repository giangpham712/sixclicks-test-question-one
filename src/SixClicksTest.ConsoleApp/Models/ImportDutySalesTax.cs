using SixClicksTest.ConsoleApp.Models.Abstract;

namespace SixClicksTest.ConsoleApp.Models
{
    public class ImportDutySalesTax : SalesTax
    {
        public override decimal Rate => 0.05M;
        public override bool IsApplicable(Product product)
        {
            return product.IsImported;
        }
    }
}