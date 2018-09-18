using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var stack = new Stack<long>();

        stack.Push(1);
        stack.Push(1);
        stack.Push(1);

        for (int i = 3; i <= n; i++)
        {
            long minusOne = stack.Pop();
            long minusTwo = stack.Pop();

            stack.Push(minusOne);

            long fibonacci = minusOne + minusTwo;
            stack.Push(fibonacci);
        }

        Console.WriteLine(stack.Peek());
    }
}

