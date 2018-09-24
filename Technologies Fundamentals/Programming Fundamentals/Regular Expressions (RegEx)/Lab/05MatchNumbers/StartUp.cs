namespace _05MatchNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            MatchCollection matchedNumbers = Regex.Matches(input, regex);

            foreach (var num in matchedNumbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }
    }
}