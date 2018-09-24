namespace _05ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string commad = Console.ReadLine();

            while (commad != "print")
            {
                var function = commad.Split().ToArray();

                if (function[0] == "add")
                {
                    int index = int.Parse(function[1]);
                    int element = int.Parse(function[2]);

                    numbers.Insert(index, element);
                }
                else if (function[0] == "addMany")
                {
                    int index = int.Parse(function[1]);

                    numbers.InsertRange(index, function.Skip(2).Select(int.Parse).ToArray());
                }
                else if (function[0] == "contains")
                {
                    int element = int.Parse(function[1]);

                    Console.WriteLine(numbers.IndexOf(element));
                }
                else if (function[0] == "remove")
                {
                    int index = int.Parse(function[1]);

                    numbers.RemoveAt(index);
                }
                else if (function[0] == "shift")
                {
                    int element = int.Parse(function[1]);
                    element = element % numbers.Count;

                    var remainder = numbers.Take(element).ToList();

                    numbers.RemoveRange(0, element);
                    numbers.AddRange(remainder);
                }
                else if (function[0] == "sumPairs")
                {
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        int sum = numbers[i] + numbers[i + 1];

                        numbers[i] = sum;
                        numbers.RemoveAt(i + 1);
                    }
                }

                commad = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }
    }
}