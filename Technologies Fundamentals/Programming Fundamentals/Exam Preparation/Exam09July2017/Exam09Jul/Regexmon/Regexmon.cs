using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Regexmon
{
    static void Main()
    {
        string input = Console.ReadLine();

        string bojomonRegex = @"[A-Za-z]+-[A-Za-z]+";
        string didimonRegex = @"[^-A-Za-z]+";

        Regex bojomon = new Regex(bojomonRegex);
        Regex didimon = new Regex(didimonRegex);

        while (true)
        {
            Match didi = didimon.Match(input);
            if (didi.Success)
            {
                Console.WriteLine(didi);
            }
            else
            {
                return;
            }

            int d = didi.Index;
            input = input.Substring(d + didi.Length);

            Match bojo = bojomon.Match(input);
            if (bojo.Success)
            {
                Console.WriteLine(bojo);
            }
            else
            {
                return;
            }

            int b = bojo.Index;
            input = input.Substring(b + bojo.Length);
        }
    }
}

