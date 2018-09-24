namespace _06ReverseArrayOfStrings
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string[] items = input.Split();

            string[] reversed = items.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}