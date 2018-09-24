namespace _06ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            char[] separators = { ' ', '\\', '/', '(', ')' };
            string[] usernames = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pattern = @"^[A-Za-z][\w]{2,26}$";

            var regex = new Regex(pattern);

            var validUsernames = new List<string>();

            foreach (var un in usernames)
            {
                if (regex.IsMatch(un))
                {
                    validUsernames.Add(un);
                }
            }

            int sum = 0;

            string smallest = string.Empty;
            string biggest = string.Empty;

            for (int i = 1; i < validUsernames.Count; i++)
            {
                int currentSum = validUsernames[i - 1].Length + validUsernames[i].Length;

                if (currentSum > sum)
                {
                    sum = currentSum;
                    smallest = validUsernames[i - 1];
                    biggest = validUsernames[i];
                }
            }

            Console.WriteLine(smallest);
            Console.WriteLine(biggest);
        }
    }
}