namespace _02ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split().ToArray();

            string command = input[0];

            while (command != "Even" && command != "Odd")
            {
                if (command == "Delete")
                {
                    int element = int.Parse(input[1]);

                    numbers.RemoveAll(x => x == element);
                }
                else if (command == "Insert")
                {
                    int element = int.Parse(input[1]);
                    int position = int.Parse(input[2]);

                    numbers.Insert(position, element);
                }

                input = Console.ReadLine().Split().ToArray();
                command = input[0];

            }

            if (command == "Odd")
            {
                foreach (int i in numbers)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else if (command == "Even")
            {
                foreach (int i in numbers)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}