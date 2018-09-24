namespace _05OnlyLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string message = Console.ReadLine();

            Regex pattern = new Regex(@"(\d+)([A-Za-z])");

            MatchCollection matches = pattern.Matches(message);

            foreach (Match m in matches)
            {
                message = Regex.Replace(message, m.Groups[1].ToString(), m.Groups[2].ToString());
            }

            Console.WriteLine(message);
        }
    }
}