using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
class ReverseNumbers
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var stack = new Stack<int>();

        foreach (var i in input)
        {
            stack.Push(i);
        }

        while (stack.Count != 0)
        {
            Console.Write(stack.Pop() + " ");
        }
        Console.WriteLine();
    }
}

