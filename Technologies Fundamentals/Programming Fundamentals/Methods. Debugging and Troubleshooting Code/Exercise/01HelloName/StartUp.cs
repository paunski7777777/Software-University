namespace _01HelloName
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            PrintName(name);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}