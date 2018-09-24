namespace _08UseYourChainsBuddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=<p>)(.*?)(?=<\/p>)";

            MatchCollection matches = Regex.Matches(input, pattern);

            StringBuilder sb = new StringBuilder();

            foreach (Match m in matches)
            {
                string str = m.Value.ToString();
                string replaced = Regex.Replace(str, "[^0-9a-z]", " ");

                for (int i = 0; i < replaced.Length; i++)
                {
                    char ch = replaced[i];

                    if (char.IsLower(ch))
                    {
                        if (ch < 110)
                        {
                            sb.Append((char)(ch + 13));
                        }
                        else
                        {
                            sb.Append((char)(ch - 13));
                        }
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
            }

            Console.WriteLine(Regex.Replace(sb.ToString(), "\\s+", " "));
        }
    }
}