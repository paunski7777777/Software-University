using System;
using System.Collections.Generic;
using System.Linq;

class BalancedParenthesis
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();

        if (input.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }

        char[] opening = new[] { '(', '{', '[' };
        char[] closing = new[] { ')', '}', ']' };

        var stack = new Stack<char>();

        foreach (var i in input)
        {
            if (opening.Contains(i))
            {
                stack.Push(i);
            }
            else if (closing.Contains(i))
            {
                var last = stack.Pop();

                int openingIndex = Array.IndexOf(opening, last);
                int closingIndex = Array.IndexOf(closing, i);

                if (openingIndex == closingIndex)
                {
                    Console.WriteLine("YES");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }
        }

        if (stack.Any())
        {
            Console.WriteLine("NO");
        }
        else
        {
            Console.WriteLine("YES");
        }
    }
}
