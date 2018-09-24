namespace _03SearchForANumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int take = array[0];
            int delete = array[1];
            int number = array[2];

            list = list.Take(take).Skip(delete).ToList();

            if (list.Contains(number))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}