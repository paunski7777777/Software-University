namespace _05WordInPlural
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            bool word1 = word.EndsWith("y");
            bool word2 = word.EndsWith("o") || word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z");
            bool word3 = word.EndsWith("ch") || word.EndsWith("sh");

            string newWord = string.Empty;

            if (word1)
            {
                newWord = word.Remove(word.Length - 1);
                Console.WriteLine($"{newWord}ies");
            }
            else if (word2)
            {
                Console.WriteLine($"{word}es");
            }
            else if (word3)
            {
                Console.WriteLine($"{word}es");
            }
            else
            {
                Console.WriteLine($"{word}s");
            }
        }
    }
}