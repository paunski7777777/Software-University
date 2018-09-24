namespace _02LineNumbers
{
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = File.ReadAllLines("Input.txt");

            var numberedLines = input.Select((line, i) => $"{i + 1}. {line}");

            File.WriteAllLines("output.txt", numberedLines);
        }
    }
}