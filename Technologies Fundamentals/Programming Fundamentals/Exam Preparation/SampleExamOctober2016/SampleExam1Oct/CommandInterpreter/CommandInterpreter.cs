using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandInterpreter
{
    static void Main()
    {
        string[] items = Console.ReadLine().Split();

        while (true)
        {
            var commandLine = Console.ReadLine().ToLower().Trim();

            if (commandLine == "end")
            {
                break;
            }

            var commandParts = commandLine.Split();
            var commandName = commandParts[0];

            ProcessCommand(items, commandName, commandParts);
        }

        Console.WriteLine($"[{string.Join(", ", items)}]");
    }
    static void ProcessCommand(string[] items, string commandName, string[] commandParts)
    {
        if (commandName == "sort" || commandName == "reverse")
        {
            ProcessSortOrReverseCommand(items, commandName, commandParts);
        }
        if (commandName == "rollleft" || commandName == "rollright")
        {
            ProcessRollCommand(items, commandName, commandParts);
        }
    }
    static void ProcessSortOrReverseCommand(string[] items, string commandName, string[] commandParts)
    {
        int start = int.Parse(commandParts[2]);
        int count = int.Parse(commandParts[4]);

        if (start < 0 || start > items.Length - 1 || start + count - 1 > items.Length - 1 || count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        if (commandName == "sort")
        {
            SortRange(items, start, count);
        }
        else if (commandName == "reverse")
        {
            ReverseRange(items, start, count);
        }
    }
    static void ProcessRollCommand(string[] items, string commandName, string[] commandParts)
    {
        int count = int.Parse(commandParts[1]);

        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        if (commandName == "rollleft")
        {
            RollRight(items, -count);
        }
        else if (commandName == "rollright")
        {
            RollRight(items, count);
        }
    }
    static void ReverseRange(string[] items, int start, int count)
    {
        int end = start + count - 1;

        while (start < end)
        {
            string oldItem = items[start];
            items[start] = items[end];
            items[end] = oldItem;
            start++;
            end--;
        }
    }
    static void SortRange(string[] items, int start, int count)
    {
        Array.Sort(items, start, count);
    }
    static void RollRight(string[] items, int count)
    {
        string[] result = new string[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            int index = i + count;
            index = index % items.Length;

            if (index < 0)
            {
                index += items.Length;
            }

            result[index] = items[i];
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = result[i];
        }
    }

}

