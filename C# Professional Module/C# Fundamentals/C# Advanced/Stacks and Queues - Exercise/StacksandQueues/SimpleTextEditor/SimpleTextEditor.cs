using System;
using System.Collections.Generic;
using System.Text;

class SimpleTextEditor
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var oldStack = new Stack<string>();
        var text = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int command = int.Parse(input[0]);

            if (command == 1)
            {
                oldStack.Push(text.ToString());
                text.Append(input[1]);
            }
            else if (command == 2)
            {
                oldStack.Push(text.ToString());
                int length = int.Parse(input[1]);
                text.Remove(text.Length - length, length);
            }
            else if (command == 3)
            {
                int index = int.Parse(input[1]);
                Console.WriteLine(text[index - 1]);
            }
            else if (command == 4)
            {
                text.Clear();
                text.Append(oldStack.Pop());
            }
        }
    }
}

