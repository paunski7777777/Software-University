namespace _06IntervalOfNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            if (m > n)
            {
                for (int i = n; i <= m; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                for (int i = m; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}