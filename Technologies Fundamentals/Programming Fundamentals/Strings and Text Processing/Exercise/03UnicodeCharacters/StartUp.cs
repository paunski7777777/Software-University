namespace _03UnicodeCharacters
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char c in input)
            {
                sb.Append("\\u");
                sb.Append(string.Format("{0:x4}", (int)c));
            }

            Console.WriteLine(sb);
        }
    }
}