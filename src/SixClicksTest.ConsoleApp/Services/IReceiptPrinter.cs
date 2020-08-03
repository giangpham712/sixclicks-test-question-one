using SixClicksTest.ConsoleApp.Models;

namespace SixClicksTest.ConsoleApp.Services
{
    public interface IReceiptPrinter
    {
        void PrintReceipt(Cart cart);
    }
}