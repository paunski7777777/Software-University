using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Snowflake
{
    static void Main()
    {
        string pattern = @"^([^A-Za-z0-9]+)([\d_]+)([A-Za-z]+)([\d_]+)([^A-Za-z0-9]+)$";
        string surface = @"^([^A-Za-z0-9]+)$";
        string mantle = @"^([\d_]+)$";

        bool valid = true;
        string snowflake = string.Empty;

        for (int i = 0; i < 5; i++)
        {
            string input = Console.ReadLine();

            if (i == 0 || i == 4)
            {
                Match match = Regex.Match(input, surface);
                if (!match.Success)
                {
                    valid = false;
                }
            }

            else if (i == 1 || i == 3)
            {
                Match match = Regex.Match(input, mantle);
                if (!match.Success)
                {
                    valid = false;
                }
            }

            else if (i == 2)
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    valid = true;
                    snowflake = match.Groups[3].Length.ToString();
                }
                else
                {
                    valid = false;
                }
            }
        }

        if (!valid)
        {
            Console.WriteLine("Invalid");
        }
        else
        {
            Console.WriteLine("Valid");
            Console.WriteLine(snowflake);
        }
    }
}

