using System;
using SixClicksTest.ConsoleApp.Models;

namespace SixClicksTest.ConsoleApp.Services
{
    public class ConsoleReceiptPrinter : IReceiptPrinter
    {
        public void PrintReceipt(Cart cart)
        {
            Console.WriteLine("Product \t Quantity \t Amount (INCL. TAX)");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Product.Name} \t {item.Quantity} \t {FormatPrice(item.AmountIncTax)}");
            }
            
            Console.WriteLine($"Tax Total: {FormatPrice(cart.TotalTaxAmount)}");
            Console.WriteLine($"Total (INCL. TAX): {FormatPrice(cart.TotalAmountIncTax)}");
            Console.WriteLine();
        }

        private static string FormatPrice(decimal price)
        {
            return price.ToString("$0.00");
        }
    }
}