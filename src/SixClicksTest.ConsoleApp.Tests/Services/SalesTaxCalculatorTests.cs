using System.Collections.Generic;
using NUnit.Framework;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Enums;
using SixClicksTest.ConsoleApp.Services;

namespace SixClicksTest.ConsoleApp.Tests.Services
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        private SalesTaxCalculator _taxCalculator;
        
        [SetUp]
        public void SetUp()
        {
            _taxCalculator = new SalesTaxCalculator();
            _taxCalculator.RegisterSalesTax(new BasicSalesTax());
            _taxCalculator.RegisterSalesTax(new ImportDutySalesTax());
        }
        
        public static IEnumerable<TestCaseData> CalculateReturnsTaxAmountTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new CartItem() { Quantity = 1, TaxAmount = 0.0M, Product = new Product("book", 12.49M, ProductType.Book, false) },
                    0.0M
                );
                yield return new TestCaseData(
                    new CartItem() { Quantity = 3, TaxAmount = 0.0M, Product = new Product("chocolate bar", 0.85M, ProductType.Food, false) },
                    0.0M
                );
                yield return new TestCaseData(
                    new CartItem() { Quantity = 10, TaxAmount = 0.0M, Product = new Product("imported bottle of perfume", 1.85M, ProductType.Other, true) },
                    2.775M
                );
            }
        }
        
        [TestCaseSource(nameof(CalculateReturnsTaxAmountTestCases))]
        public void Calculate_ValidLine_ReturnsExpectedCartItem(CartItem item, decimal expectedTaxAmount)
        {
            var actual = _taxCalculator.Calculate(item);
 
            // Assert
            Assert.AreEqual(expectedTaxAmount, actual);
        }
    }
}