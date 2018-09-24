namespace _05ShortWordsSorted
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            char[] separators = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\\', '\"', '\'', '/', '!', '?', ' ' };

            string[] text = Console.ReadLine().ToLower().Split(separators).ToArray();

            var result = text
                        .Where(s => s != "")
                        .Where(s => s.Length < 5)
                        .OrderBy(s => s)
                        .Distinct()
                        .ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}