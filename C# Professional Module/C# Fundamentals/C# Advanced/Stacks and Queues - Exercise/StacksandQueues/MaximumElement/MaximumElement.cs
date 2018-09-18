using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class MaximumElement
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();
        var maxStack = new Stack<int>();

        maxStack.Push(int.MinValue);

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            string command = input[0];

            if (command == "1")
            {
                int number = int.Parse(input[1]);
                stack.Push(number);

                if (number >= maxStack.Peek())
                {
                    maxStack.Push(number);
                }
            }
            else if (command == "2")
            {
                var popped = stack.Pop();

                if (maxStack.Peek() == popped)
                {
                    maxStack.Pop();
                }
            }
            else if (command == "3")
            {
                int max = maxStack.Peek();
                Console.WriteLine(max);
            }
        }
    }
}

