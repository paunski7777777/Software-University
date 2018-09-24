namespace _10SumOfChars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char letters = char.Parse(Console.ReadLine());

                sum += letters;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}