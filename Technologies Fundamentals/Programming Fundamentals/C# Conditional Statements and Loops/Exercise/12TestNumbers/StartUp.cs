namespace _12TestNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            int total = 0;
            int count = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (total >= sum)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                        total += 3 * (i * j);
                    }
                }
            }

            if (total >= sum)
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {total} >= {sum}");
            }
            else
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {total}");
            }
        }
    }
}