namespace _02IndexOfLetters
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            // var input = File.ReadAllText("input.txt");
            var input2 = File.ReadAllText("input2.txt");

            // char[] letters = input.ToCharArray();
            char[] letters = input2.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                // File.AppendAllText("output.txt", $"{letters[i].ToString()} -> {letters[i] - 'a'}");
                File.AppendAllText("output2.txt", $"{letters[i].ToString()} -> {letters[i] - 'a'}");
                // File.AppendAllText("output.txt", Environment.NewLine);
                File.AppendAllText("output2.txt", Environment.NewLine);
            }
        }
    }
}