namespace _08Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            List<char> mineLine = input.ToCharArray().ToList();

            MatchCollection matches = Regex.Matches(input, @"<..>");

            foreach (Match mine in matches)
            {
                int index = mineLine.IndexOf(mine.ToString()[0]);

                int mineStartIndex = index + 1;
                int mineEndIndex = index + 2;

                char mineFirstLetter = input[mineStartIndex];
                char mineSecondLetter = input[mineEndIndex];

                int minePower = Math.Abs(mineFirstLetter - mineSecondLetter);

                int blastAwayStartIndex = index - minePower;
                int blastAwayEndIndex = index - 1 + 4 + minePower;

                if (blastAwayStartIndex < 0)
                {
                    blastAwayStartIndex = 0;
                }

                if (blastAwayEndIndex >= mineLine.Count)
                {
                    blastAwayEndIndex = mineLine.Count - 1;
                }

                for (int i = blastAwayStartIndex; i <= blastAwayEndIndex; i++)
                {
                    mineLine.RemoveAt(i);
                    mineLine.Insert(i, '_');
                }
            }

            Console.WriteLine(string.Join("", mineLine));
        }
    }
}