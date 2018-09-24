using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class AnonymousVox
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] placeholder = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
        string pattern = @"([A-Za-z]+)(.*)(\1)";

        MatchCollection matches = Regex.Matches(input, pattern);
        int index = 0;

        foreach (Match m in matches)
        {
            string newValue = m.Groups[1] + placeholder[index++] + m.Groups[3];
            input = input.Replace(m.Value, newValue);
        }

        Console.WriteLine(input);
    }
}

