using SixClicksTest.ConsoleApp.Models;
using SixClicksTest.ConsoleApp.Models.Abstract;

namespace SixClicksTest.ConsoleApp.Services
{
    public interface ITaxCalculator
    {
        void RegisterSalesTax(SalesTax tax);
        decimal Calculate(CartItem item);
    }
}    