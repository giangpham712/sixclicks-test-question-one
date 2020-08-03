using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Enums;

namespace SixClicksTest.ConsoleApp.Services
{
    public class CartItemReader : ICartItemReader
    {
        private const string LineItemPattern = @"(\d+) ([\w\s]*) at \$(\d+\.\d{1,2})";
        private static readonly IDictionary<string, ProductType> ProductTypeKeywords = new Dictionary<string, ProductType>()
        {
            // Assume that the type of a product can be identified by its name containing any of these keywords, otherwise its type is Other
            { "book", ProductType.Book },
            { "chocolate", ProductType.Food }, 
            { "chocolates", ProductType.Food  }
        }; 
        
        public CartItem Read(string line)
        {
            var match = Regex.Match(line, LineItemPattern, RegexOptions.IgnoreCase);
            if (!match.Success || match.Groups.Count != 4)
            {
                throw new FormatException($"Line has invalid format: {line}");
            }

            var quantity = int.Parse(match.Groups[1].Value);
            var productName = match.Groups[2].Value;
            var productPrice = decimal.Parse(match.Groups[3].Value);
            var productType = GetProductType(productName);
            
            // Assume that any product whose name contains the word 'imported' is an imported product
            var isProductImported = productName.ToLower().Contains("imported"); 

            var product = new Product(productName, productPrice, productType, isProductImported);
            return new CartItem()
            {
                Product = product,
                Quantity = quantity
            };
        }
        
        private static ProductType GetProductType(string productName)
        {
            var foundKeyword = productName.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(word => ProductTypeKeywords.ContainsKey(word));

            return foundKeyword != null ? ProductTypeKeywords[foundKeyword] : ProductType.Other;
        }
    }
}