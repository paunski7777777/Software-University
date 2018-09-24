namespace _06TriplesOfLetters
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write($"{(char)('a' + i)}{(char)('a' + j)}{(char)('a' + k)} ");
                    }
                }
            }
        }
    }
}