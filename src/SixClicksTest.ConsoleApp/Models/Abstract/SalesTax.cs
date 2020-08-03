namespace SixClicksTest.ConsoleApp.Models.Abstract
{
    public abstract class SalesTax
    {
        public abstract decimal Rate { get; }
        public abstract bool IsApplicable(Product product);

        public decimal Calculate(Product product)
        {
            if (!IsApplicable(product))
                return 0;

            return product.Price * Rate;
        }
    }
}