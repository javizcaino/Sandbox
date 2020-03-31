namespace HelloWorld
{
    using System;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\nWhat is your name? ");
            string name = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}