namespace _07Hideout
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string map = Console.ReadLine();

            while (true)
            {
                string[] arr = Console.ReadLine().Split();

                string searchedChar = Regex.Escape(arr[0]);
                int count = int.Parse(arr[1]);

                string pattern = $@"[{searchedChar}]+";

                foreach (Match m in Regex.Matches(map, pattern))
                {
                    if (m.Length >= count)
                    {
                        Console.WriteLine($"Hideout found at index {m.Index} and it is with size {m.Length}!");
                        return;
                    }
                }
            }
        }
    }
}