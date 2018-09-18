using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Regeh
{
    static void Main()
    {
        string pattern = @"\[(\w+)<(\d+)REGEH(\d+)>(\w+)\]";
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, pattern);

        var numbers = new List<int>();
        var result = new StringBuilder();

        foreach (Match m in matches)
        {
            var currentNumber = m;
            int leftNumber = int.Parse(currentNumber.Groups[2].Value);
            int rightNumber = int.Parse(currentNumber.Groups[3].Value);

            numbers.Add(leftNumber);
            numbers.Add(rightNumber);
        }

        int index = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            index += numbers[i];

            if (index > input.Length - 1)
            {
                index %= input.Length - 1;
            }

            result.Append(input[index]);
        }

        Console.WriteLine(result);
    }
}

