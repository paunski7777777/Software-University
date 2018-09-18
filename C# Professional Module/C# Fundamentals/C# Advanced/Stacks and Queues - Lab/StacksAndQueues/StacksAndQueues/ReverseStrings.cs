using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseStrings
{
    static void Main()
    {
        string input = Console.ReadLine();
        var stack = new Stack<char>();

        foreach (var i in input)
        {
            stack.Push(i);
        }

        while (stack.Count != 0)
        {
            Console.Write(stack.Pop());
        }
        Console.WriteLine();
    }
}

