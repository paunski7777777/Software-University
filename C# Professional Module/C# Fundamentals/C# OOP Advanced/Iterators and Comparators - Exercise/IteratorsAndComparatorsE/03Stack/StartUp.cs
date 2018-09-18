using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var myStack = new CustomStack<int>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            if (command == "Push")
            {
                var numbers = tokens.Skip(1).Select(int.Parse).ToList();

                foreach (var n in numbers)
                {
                    myStack.Push(n);
                }
            }
            else
            {
                try
                {
                    myStack.Pop();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        if (myStack.Any())
        {
            Console.WriteLine(string.Join(Environment.NewLine, myStack));
            Console.WriteLine(string.Join(Environment.NewLine, myStack));
        }
    }
}