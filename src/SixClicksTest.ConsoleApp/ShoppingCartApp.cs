using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Enums;
using SixClicksTest.ConsoleApp.Services;

namespace SixClicksTest.ConsoleApp
{
    public class ShoppingCartApp
    {
        private ICartItemReader _itemReader;
        private ITaxCalculator _taxCalculator;
        private IReceiptPrinter _receiptPrinter;

        public ShoppingCartApp(ICartItemReader itemReader, ITaxCalculator taxCalculator, IReceiptPrinter receiptPrinter)
        {
            _itemReader = itemReader;
            _taxCalculator = taxCalculator;
            _receiptPrinter = receiptPrinter;
        }

        public void ProcessCartInput(string[] lines)
        {
            try
            {
                var cart = new Cart();
                foreach (var line in lines)
                {
                    var cartItem = _itemReader.Read(line);
                    cart.AddItem(cartItem);
                }

                cart.CalculateTax(_taxCalculator);
                _receiptPrinter.PrintReceipt(cart);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while processing cart input - {e.Message}");
                Console.WriteLine();
            }
        }
    }
}