namespace _13GameOfNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int count = 0;

            int currentI = 0;
            int currentJ = 0;

            bool done = false;

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    count++;
                    if (i + j == magicNumber)
                    {
                        currentI = i;
                        currentJ = j;
                        done = true;
                    }
                }
            }

            if (done)
            {
                Console.WriteLine($"Number found! {currentI} + {currentJ} = {magicNumber}");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
            }
        }
    }
}