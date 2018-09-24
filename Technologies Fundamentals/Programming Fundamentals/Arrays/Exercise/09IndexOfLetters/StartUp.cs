namespace _09IndexOfLetters
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char[] letters = Console.ReadLine().ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                Console.WriteLine($"{letters[i]} -> {letters[i] - 'a'}");
            }
        }
    }
}