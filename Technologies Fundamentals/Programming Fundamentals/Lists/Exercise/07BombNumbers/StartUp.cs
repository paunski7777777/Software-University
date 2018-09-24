namespace _07BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bomb = Console.ReadLine().Split().Select(int.Parse).ToList();

            int special = bomb[0];
            int power = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == special)
                {
                    int left = Math.Max(i - power, 0);
                    int right = Math.Min(i + power, numbers.Count - 1);
                    int length = right - left + 1;

                    numbers.RemoveRange(left, length);

                    i = 0;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}