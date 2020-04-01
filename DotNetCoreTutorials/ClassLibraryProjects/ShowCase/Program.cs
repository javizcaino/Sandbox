namespace ShowCase
{
    using System;

    using UtilityLibraries;

    public static class Program
    {
        public static void Main(string[] args)
        {
            int row = 0;

            while (true)
            {
                if (row == 0 || row >= 25)
                {
                    ResetConsole();
                }

                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                Console.WriteLine($"Input: {input} {"Begins with uppercase? ",30}: " +
                                  $"{(input.StartsWithUpper() ? "Yes" : "No")}\n");
                row += 3;
            }

            return;

            // Declare a ResetConsole local method
            void ResetConsole()
            {
                if (row > 0)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                Console.Clear();
                Console.WriteLine("\nPress <Enter> only to exit; otherwise, enter a string and press <Enter>:\n");
                row = 3;
            }
        }
    }
}