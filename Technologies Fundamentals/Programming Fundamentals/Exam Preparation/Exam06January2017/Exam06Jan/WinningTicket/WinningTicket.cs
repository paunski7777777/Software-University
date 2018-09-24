using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class WinningTicket
{
    static void Main()
    {
        var tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        char[] win = { '#', '$', '@', '^' };
        bool isMatch = false;

        foreach (var t in tickets)
        {
            if (t.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }

            string left = t.Substring(0, 10);
            string right = t.Substring(10, 10);
            string pattern = string.Empty;
            int leftO = 0;
            int rightO = 0;
            int total = 0;

            foreach (var w in win)
            {
                if (w == '^')
                {
                    pattern = @"[\^]{6,}";
                }
                else
                {
                    pattern = @"[" + w + "]{6,}";
                }

                leftO = Regex.Match(left, pattern).Length;
                rightO = Regex.Match(right, pattern).Length;
                total = Math.Min(leftO, rightO);

                if (Regex.IsMatch(left, pattern) && Regex.IsMatch(right, pattern))
                {
                    isMatch = true;

                    if (total >= 6 && total <= 9)
                    {
                        Console.WriteLine($"ticket \"{t}\" - {total}{w}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{t}\" - 10{w} Jackpot!");
                    }
                    continue;
                }
            }
            if (!isMatch)
            {
                Console.WriteLine($"ticket \"{t}\" - no match");
            }

            isMatch = false;
        }
    }
}

