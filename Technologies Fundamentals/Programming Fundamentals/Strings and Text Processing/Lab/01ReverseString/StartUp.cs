namespace _01ReverseString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            char[] output = input.ToCharArray();
            Array.Reverse(output);

            Console.WriteLine(output);
        }
    }
}