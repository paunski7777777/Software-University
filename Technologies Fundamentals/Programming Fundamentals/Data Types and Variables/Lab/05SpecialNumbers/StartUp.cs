namespace _05SpecialNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int dig = i;

                while (dig > 0)
                {
                    sum += dig % 10;
                    dig = dig / 10;
                }

                bool num = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {num}");
            }
        }
    }
}