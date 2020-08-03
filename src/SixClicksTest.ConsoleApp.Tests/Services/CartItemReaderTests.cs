using System;
using System.Collections.Generic;
using NUnit.Framework;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Enums;
using SixClicksTest.ConsoleApp.Services;

namespace SixClicksTest.ConsoleApp.Tests.Services
{
    [TestFixture]
    public class CartItemReaderTests
    {
        private CartItemReader _itemReader;

        [SetUp]
        public void SetUp()
        {
            _itemReader = new CartItemReader();
        }
        
        public static IEnumerable<TestCaseData> ReadValidLineReturnsExpectedCartItemTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "1 book at $12.49", 
                    new CartItem() { Quantity = 1, TaxAmount = 0.0M, Product = new Product("book", 12.49M, ProductType.Book, false) }
                );
                yield return new TestCaseData(
                    "3 chocolate bar at $0.85", 
                    new CartItem() { Quantity = 3, TaxAmount = 0.0M, Product = new Product("chocolate bar", 0.85M, ProductType.Food, false) }
                );
                yield return new TestCaseData(
                    "10 imported bottle of perfume at $1.85", 
                    new CartItem() { Quantity = 10, TaxAmount = 0.0M, Product = new Product("imported bottle of perfume", 1.85M, ProductType.Other, true) }
                );
            }
        }
        
        [TestCaseSource(nameof(ReadValidLineReturnsExpectedCartItemTestCases))]
        public void Read_ValidLine_ReturnsExpectedCartItem(string line, CartItem expected)
        {
            var actual = _itemReader.Read(line);
 
            // Assert
            Assert.NotNull(expected.Product);
            Assert.AreEqual(expected.Product, actual.Product);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
            Assert.AreEqual(expected.TaxAmount, actual.TaxAmount);
        }

        [TestCase("1 music CD ta $14.99")]
        public void Read_InvalidLine_ThrowsException(string line)
        {
            Assert.That(() => _itemReader.Read(line), Throws.TypeOf<FormatException>());
        }
    }
}