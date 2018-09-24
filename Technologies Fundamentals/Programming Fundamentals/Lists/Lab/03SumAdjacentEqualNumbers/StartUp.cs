namespace _03SumAdjacentEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            while (true)
            {
                bool res = false;
                double sum = 0;

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        sum = numbers[i] + numbers[i + 1];

                        numbers.RemoveRange(i, 2);
                        numbers.Insert(i, sum);

                        res = true;
                    }
                }

                if (!res)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}