using System;
using SixClicksTest.ConsoleApp.Models.Enums;

namespace SixClicksTest.ConsoleApp.Models
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public ProductType Type { get; }
        public bool IsImported { get; }

        public Product(string name, decimal price, ProductType type, bool isImported)
        {
            Name = name;
            Price = price;
            Type = type;
            IsImported = isImported;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            return Equals(other);
        }

        private bool Equals(Product other)
        {
            return null != other && 
                   Name == other.Name && 
                   Price == other.Price && 
                   Type == other.Type && 
                   IsImported == other.IsImported;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, (int) Type, IsImported);
        }
    }
}