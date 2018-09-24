namespace _01X
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', i - 1),
                                                 new string(' ', n - i - i),
                                                 new string(' ', i));
            }

            Console.WriteLine("{0}x{0}", new string(' ', n / 2));

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', n / 2 - i - 1),
                                                 new string(' ', i + i + 1),
                                                 new string(' ', n / 2 - i));
            }
        }
    }
}