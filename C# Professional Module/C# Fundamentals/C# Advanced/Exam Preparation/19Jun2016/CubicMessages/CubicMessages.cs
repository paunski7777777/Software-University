using System;
using System.Text;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        string pattern = @"^(\d+)([A-Za-z]+)([^A-Za-z]*)$";

        string input;
        while ((input = Console.ReadLine()) != "Over!")
        {
            int message = int.Parse(Console.ReadLine());
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string firstPart = match.Groups[1].Value;
                string middlePart = match.Groups[2].Value;
                string lastPart = string.Empty;
                if (match.Groups[3].Value != "")
                {
                    lastPart = match.Groups[3].Value;
                }

                if (middlePart.Length != message)
                {
                    continue;
                }

                string indexes = Regex.Replace(firstPart + lastPart, @"\D*", string.Empty);
                var sb = new StringBuilder();

                foreach (var i in indexes)
                {
                    int index = int.Parse(i.ToString());
                    
                    if (index >= 0 && index < message)
                    {
                        sb.Append(middlePart[index]);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                Console.WriteLine($"{middlePart} == {sb}");
            }
        }
    }
}

