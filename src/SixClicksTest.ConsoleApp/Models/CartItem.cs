namespace SixClicksTest.ConsoleApp.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount => Product.Price * Quantity;
        public decimal AmountIncTax => Amount + TaxAmount;
    }
}