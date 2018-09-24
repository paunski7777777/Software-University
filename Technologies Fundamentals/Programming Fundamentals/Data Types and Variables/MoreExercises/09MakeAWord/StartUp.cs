namespace _09MakeAWord
{
    using System;

    public class StartUp
    {
        public static void Main()
        {

            int n = int.Parse(Console.ReadLine());

            string word = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char chars = char.Parse(Console.ReadLine());

                word += chars;
            }

            Console.WriteLine($"The word is: {word}");
        }
    }
}