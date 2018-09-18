using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class CryptoBlockchain
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string pattern = @"(\{[^\[\]\{\}]*?[^\{\}\[\]]*?\})|\[[^\[\]\{\}]*?[^\{\}\[\]]*?\]";
        string digitPattern = @"\d{3,}";

        var inputLine = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            inputLine.Append(input);
        }

        MatchCollection matches = Regex.Matches(inputLine.ToString(), pattern);

        foreach (Match match in matches)
        {
            MatchCollection numberMatches = Regex.Matches(match.ToString(), digitPattern);

            if (match.Success)
            {
                string result = string.Empty;
                int number = 0;

                foreach (Match num in Regex.Matches(match.ToString(), digitPattern))
                {
                    string current = num.ToString();

                    int length = current.Length;
                    int parts = 3;

                    if (length % 3 == 0)
                    {
                        for (int i = 0; i < length; i += parts)
                        {
                            if (i + parts > length)
                            {
                                parts = length - i;
                            }

                            result = current.Substring(i, parts);
                            number = int.Parse(result);
                            number -= match.Length;

                            Console.Write((char)number);
                        }
                    }
                }
            }
        }

        Console.WriteLine();
    }
}

