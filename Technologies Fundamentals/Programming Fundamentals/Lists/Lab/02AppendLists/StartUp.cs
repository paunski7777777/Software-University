namespace _02AppendLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine().Split('|').ToList();
            numbers.Reverse();

            List<string> result = new List<string>();

            foreach (string num in numbers)
            {
                List<string> nums = num.Split().ToList();

                foreach (string n in nums)
                {
                    if (num != "")
                    {
                        result.Add(n);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}