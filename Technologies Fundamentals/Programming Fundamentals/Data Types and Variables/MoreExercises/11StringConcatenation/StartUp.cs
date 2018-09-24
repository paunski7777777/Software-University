namespace _11StringConcatenation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char sym = char.Parse(Console.ReadLine());
            byte type = Console.ReadLine() == "even" ? (byte)0 : (byte)1;
            int n = int.Parse(Console.ReadLine());

            string word = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == type)
                {
                    word += Console.ReadLine() + sym;
                }
                else
                {
                    Console.ReadLine();
                }
            }

            Console.WriteLine(word.Remove(word.Length - 1));
        }
    }
}