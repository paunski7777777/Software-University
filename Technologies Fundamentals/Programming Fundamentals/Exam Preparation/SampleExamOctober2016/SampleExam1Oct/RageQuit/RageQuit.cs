using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"([^0-9]+)(\d+)";

        var result = new StringBuilder();

        foreach (Match match in Regex.Matches(input, pattern))
        {
            string word = match.Groups[1].Value.ToUpper();
            int count = int.Parse(match.Groups[2].Value);

            for (int i = 0; i < count; i++)
            {
                result.Append(word);
            }
        }

        int uniqueChars = result.ToString().Distinct().Count();

        Console.WriteLine($"Unique symbols used: {uniqueChars}");
        Console.WriteLine(result);
    }
}

