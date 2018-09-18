using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SimpleCalculator
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        var stack = new Stack<string>(input.Reverse());

        while (stack.Count > 1)
        {
            int first = int.Parse(stack.Pop());
            string operand = stack.Pop();
            int second = int.Parse(stack.Pop());

            switch (operand)
            {
                case "+":
                    stack.Push((first + second).ToString());
                    break;
                case "-":
                    stack.Push((first - second).ToString());
                    break;
            }
        }
        Console.WriteLine(stack.Pop());
    }
}

