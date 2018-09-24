namespace _05AMinerTask
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var sequence = new Dictionary<string, int>();

            string[] inputFile = File.ReadAllLines("input.txt");

            File.WriteAllText("output.txt", string.Empty);

            for (int i = 0; i < inputFile.Length; i += 2)
            {
                string input = inputFile[i];

                if (input == "stop")
                {
                    break;
                }

                int n = int.Parse(inputFile[i + 1]);

                if (!sequence.ContainsKey(input))
                {
                    sequence.Add(input, 0);
                }

                sequence[input] += n;
            }

            foreach (var item in sequence)
            {
                File.AppendAllText("output.txt", $"{item.Key} -> {item.Value}");
                File.AppendAllText("output.txt", Environment.NewLine);
            }
        }
    }
}