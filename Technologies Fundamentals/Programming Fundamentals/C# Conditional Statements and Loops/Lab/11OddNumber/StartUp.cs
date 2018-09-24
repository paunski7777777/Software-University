namespace _11OddNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                int n = int.Parse(Console.ReadLine());

                if (n % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                }
                else
                {
                    if (n > 0)
                    {
                        Console.WriteLine($"The number is: {n}");
                        break;
                    }
                    else if (n < 0)
                    {
                        Console.WriteLine($"The number is: {n - (2 * n)}");
                        break;
                    }
                }
            }
        }
    }
}