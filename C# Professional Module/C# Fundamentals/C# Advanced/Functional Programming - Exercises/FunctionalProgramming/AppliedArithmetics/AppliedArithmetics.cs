using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AppliedArithmetics
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string command = Console.ReadLine();

        while (command != "end")
        {
            if (command == "add")
                Add(numbers);
            else if (command == "multiply")
                Multiply(numbers);
            else if (command == "subtract")
                Subtract(numbers);
            else if (command == "print")
                Print(numbers);

            command = Console.ReadLine();
        }
    }

    private static void Print(List<int> numbers)
    {
        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void Subtract(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i]--;
        }
    }

    private static void Multiply(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] *= 2;
        }
    }

    private static void Add(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i]++;
        }
    }
}

