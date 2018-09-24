namespace _10MultiplicationTable2._0
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            if (m >= 0 && m <= 10)
            {
                for (int i = m; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
            else
            {
                Console.WriteLine($"{n} X {m} = {n * m}");
            }
        }
    }
}