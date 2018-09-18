using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatchingBrackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        var stack = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                stack.Push(i);
            }
            if (input[i] == ')')
            {
                int openBracket = stack.Pop();
                int length = i - openBracket + 1;
                Console.WriteLine(input.Substring(openBracket, length));
            }
        }
    }
}

