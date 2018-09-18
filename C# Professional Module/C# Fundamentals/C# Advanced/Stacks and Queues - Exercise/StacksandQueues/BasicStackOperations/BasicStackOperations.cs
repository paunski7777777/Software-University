using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = array[0];
        int s = array[1];
        int x = array[2];

        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var stack = new Stack<int>();

        foreach (var l in list.Take(n).ToList())
        {
            stack.Push(l);
        }

        for (int i = 0; i < s; i++)
        {
            stack.Pop();
        }

        if (stack.Contains(x))
        {
            Console.WriteLine("true");
        }
        else if (stack.Count < 1)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}

