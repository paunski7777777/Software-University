namespace _02CountSubstringOccurrences
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();

            int count = 0;
            var index = -1;

            while (true)
            {
                index = text.IndexOf(pattern, index + 1);

                if (index == -1)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}