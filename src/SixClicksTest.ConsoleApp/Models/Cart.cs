using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using SixClicksTest.ConsoleApp.Services;

namespace SixClicksTest.ConsoleApp.Models
{
    public class Cart
    {
        private List<CartItem> _items;
        public IEnumerable<CartItem> Items => _items;
        public decimal TotalAmount => this._items.Sum(item => item.Amount);
        public decimal TotalTaxAmount => this._items.Sum(item => item.TaxAmount);
        public decimal TotalAmountIncTax => TotalAmount + TotalTaxAmount;

        public Cart()
        {
            _items = new List<CartItem>();
        }
        public void AddItem(CartItem item)
        {
            _items.Add(item);
        }

        public void CalculateTax(ITaxCalculator taxCalculator)
        {
            foreach (var item in _items)
            {
                item.TaxAmount = taxCalculator.Calculate(item);
            }
        }
    }
}