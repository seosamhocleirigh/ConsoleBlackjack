using System;

namespace ConsoleBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do {
                while (! Console.KeyAvailable) {
                    // Do something
                }       
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);   
        }
    }
}
