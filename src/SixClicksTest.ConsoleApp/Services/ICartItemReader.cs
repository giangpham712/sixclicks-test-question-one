using SixClicksTest.ConsoleApp.Models;

namespace SixClicksTest.ConsoleApp.Services
{
    public interface ICartItemReader
    {
        CartItem Read(string line);
    }
}