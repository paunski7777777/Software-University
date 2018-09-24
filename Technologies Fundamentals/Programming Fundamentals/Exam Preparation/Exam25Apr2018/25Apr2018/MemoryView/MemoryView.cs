using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class MemoryView
{
    public static void Main()
    {
        string middlePartPattern = @"( 0 (\d+) 0 )";

        var values = new List<string>();
        var sb = new StringBuilder();

        string input;
        while ((input = Console.ReadLine()) != "Visual Studio crash")
        {
            sb.Append(input + " ");
        }

        int value = 0;
        var numbers = new List<int>();

        foreach (Match match in Regex.Matches(sb.ToString(), middlePartPattern))
        {
            int number = int.Parse(match.Groups[2].Value);
            if (number > 0)
            {
                value = number;
                numbers.Add(value);
            }

        }

        for (int i = 0; i < numbers.Count; i++)
        {
            string pattern = $@"(32656 19759 32763)( 0 (\d+) 0 )((\d+ ){{{numbers[i]}}})";

            foreach (Match m in Regex.Matches(sb.ToString(), pattern))
            {
                Console.WriteLine(m);
            }
        }
    }
}
