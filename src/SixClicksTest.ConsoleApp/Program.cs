using System;
using System.IO;
using System.Text.RegularExpressions;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Enums;
using SixClicksTest.ConsoleApp.Services;

namespace SixClicksTest.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemParser = new CartItemReader();
            var taxCalculator = new SalesTaxCalculator();
            taxCalculator.RegisterSalesTax(new BasicSalesTax());
            taxCalculator.RegisterSalesTax(new ImportDutySalesTax());
            
            var receiptPrinter = new ConsoleReceiptPrinter();
            
            var shoppingCartApp = new ShoppingCartApp(itemParser, taxCalculator, receiptPrinter);

            shoppingCartApp.ProcessCartInput(
                File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Inputs", "cart1.txt"))
            );
            
            shoppingCartApp.ProcessCartInput(
                File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Inputs", "cart2.txt"))
            );
        }
    }
}