namespace _01SortTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> time = Console.ReadLine().Split().OrderBy(t => t).ToList();

            Console.WriteLine(string.Join(", ", time));
        }
    }
}