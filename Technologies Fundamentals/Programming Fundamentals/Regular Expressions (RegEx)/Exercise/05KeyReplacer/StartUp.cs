namespace _05KeyReplacer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            string pattern = @"^(?<startKey>[a-zA-Z]*)(?:\<|\||\\)(?:.+)(?:\<|\||\\)(?<endKey>[a-zA-Z]*)$";

            Match match = Regex.Match(key, pattern);

            if (match.Success)
            {
                string startKey = match.Groups["startKey"].Value;
                string endKey = match.Groups["endKey"].Value;

                string pattern2 = $@"{startKey}(?<word>.*?){endKey}";
                MatchCollection matches = Regex.Matches(text, pattern2);

                var result = new StringBuilder();

                foreach (Match m in matches)
                {
                    result.Append(m.Groups["word"].Value);
                }

                if (result.ToString().Length == 0)
                {
                    Console.WriteLine("Empty result");
                }
                else
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}