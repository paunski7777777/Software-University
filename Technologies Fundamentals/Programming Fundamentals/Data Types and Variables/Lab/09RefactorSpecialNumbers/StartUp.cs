namespace _09RefactorSpecialNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                int sum = 0;
                int specialNumber = i;

                while (specialNumber > 0)
                {
                    sum += specialNumber % 10;
                    specialNumber = specialNumber / 10;
                }

                bool boolResult = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {boolResult}");
            }
    }
}