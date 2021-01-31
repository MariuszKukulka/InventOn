using System;
namespace InventOn.PresentationLayer
{
    public class ConsolePresentationService : IPresentationService
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
