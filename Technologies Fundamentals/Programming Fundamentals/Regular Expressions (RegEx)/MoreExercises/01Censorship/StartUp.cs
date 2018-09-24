namespace _01Censorship
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            foreach (var i in input)
            {
                if (input.Contains(word))
                {
                    input = input.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine(input);
        }
    }
}