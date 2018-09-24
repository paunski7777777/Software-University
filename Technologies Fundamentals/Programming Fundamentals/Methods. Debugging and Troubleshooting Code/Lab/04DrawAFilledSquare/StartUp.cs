namespace _04DrawAFilledSquare
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintTop(n);
            PrintMiddle(n);
            PrintTop(n);
        }

        private static void PrintTop(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }

        private static void PrintMiddle(int n)
        {
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("-");

                for (int j = 1; j < n; j++)
                {
                    Console.Write("\\/");
                }

                Console.WriteLine("-");
            }
        }
    }
}