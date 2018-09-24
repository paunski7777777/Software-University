using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ArrayManipulator
{
    static List<int> sequence;
    static void Main()
    {
        sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
        string input = Console.ReadLine();

        while (input != "end")
        {
            string[] commands = input.Split();
            ParseCommand(commands);

            input = Console.ReadLine();
        }

        Console.WriteLine($"[{string.Join(", ", sequence)}]");
    }

    private static void ParseCommand(string[] commands)
    {
        switch (commands[0])
        {
            case "exchange":
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < sequence.Count)
                    {
                        sequence = Exchange(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                    break;
                }
            case "max":
                {
                    int isOdd = ParseIsOdd(commands[1]);
                    int max = Max(isOdd);

                    if (max >= 0)
                    {
                        Console.WriteLine(max);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                    break;
                }
            case "min":
                {
                    int isOdd = ParseIsOdd(commands[1]);
                    int min = Min(isOdd);

                    if (min >= 0)
                    {
                        Console.WriteLine(min);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                    break;
                }
            case "first":
                {
                    int count = int.Parse(commands[1]);
                    int isOdd = ParseIsOdd(commands[2]);

                    if (count >= 0 && count <= sequence.Count)
                    {
                        List<int> firstElements = First(count, isOdd);
                        Console.WriteLine($"[{string.Join(", ", firstElements)}]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    break;
                }
            case "last":
                {
                    int count = int.Parse(commands[1]);
                    int isOdd = ParseIsOdd(commands[2]);

                    if (count >= 0 && count <= sequence.Count)
                    {
                        List<int> lastElements = Last(count, isOdd);
                        Console.WriteLine($"[{string.Join(", ", lastElements)}]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }

                    break;
                }
        }
    }

    private static int ParseIsOdd(string commands)
    {
        return commands == "odd" ? 1 : 0;
    }

    static List<int> Exchange(int index)
    {
        var firstElements = sequence.Take(index + 1);
        var secondElements = sequence.Skip(index + 1);

        return secondElements.Concat(firstElements).ToList();
    }

    static int Max(int isOdd)
    {
        int max = 0;
        var filteredElements = sequence.Where(x => x % 2 == isOdd);

        if (filteredElements.Count() > 0)
        {
            max = filteredElements.Max();
        }
        else
        {
            return -1;
        }

        return sequence.LastIndexOf(max);
    }

    static int Min(int isOdd)
    {
        int min = 0;
        var filteredElements = sequence.Where(x => x % 2 == isOdd);

        if (filteredElements.Count() > 0)
        {
            min = filteredElements.Min();
        }
        else
        {
            return -1;
        }

        return sequence.LastIndexOf(min);
    }

    static List<int> First(int count, int isOdd)
    {
        var firstElements = sequence.Where(x => x % 2 == isOdd).Take(count).ToList();

        return firstElements;
    }

    static List<int> Last(int count, int isOdd)
    {
        var filteredElements = sequence.Where(x => x % 2 == isOdd);
        var lastElements = filteredElements.Skip(filteredElements.Count() - count).ToList();

        return lastElements;
    }
}

