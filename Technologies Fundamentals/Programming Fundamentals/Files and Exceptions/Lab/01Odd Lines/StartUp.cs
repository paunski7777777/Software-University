namespace _01Odd_Lines
{
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = File.ReadAllLines("Input.txt");

            var oddLines = input.Where((line, i) => i % 2 == 1);

            File.WriteAllLines("oddLines.txt", oddLines);
        }
    }
}