namespace _04Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            string[] text = Console.ReadLine().Split(new char[] { ',', '?', ' ', '.', '!' }, StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(text);

            List<string> sorted = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (IsPalindrome(text[i]))
                {
                    sorted.Add(text[i]);
                }
            }

            Console.WriteLine(string.Join(", ", sorted.Distinct()));
        }

        private static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}