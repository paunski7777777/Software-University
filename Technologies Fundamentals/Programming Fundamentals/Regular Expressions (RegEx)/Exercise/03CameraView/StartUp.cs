namespace _03CameraView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int skip = numbers[0];
            int take = numbers[1];

            string input = Console.ReadLine();

            var cameras = new List<string>();

            string pattern = $"\\|\\<(.{{0,{skip}}})(.{{0,{take}}})";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            while (input.Length > match.Index + 2 && match.Success)
            {
                string matchToAdd = match.Groups[2].Value;

                if (matchToAdd.Contains("|"))
                {
                    matchToAdd = matchToAdd.Substring(0, matchToAdd.IndexOf
                        ("|"));
                }
                if (matchToAdd.Contains("<"))
                {
                    matchToAdd = matchToAdd.Substring(0, matchToAdd.IndexOf
                        ("<"));
                }

                cameras.Add(matchToAdd);

                input = input.Substring(match.Index + 2);
                match = regex.Match(input);
            }

            Console.WriteLine(string.Join(", ", cameras));
        }
    }
}