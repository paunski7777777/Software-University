namespace _05MagicExchangeableWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string word1 = input[0];
            string word2 = input[1];

            char[] array1 = word1.ToCharArray().Distinct().ToArray();
            char[] array2 = word2.ToCharArray().Distinct().ToArray();

            if (array1.Length == array2.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}