namespace _06FixEmails
{
    using System;
    using System.IO;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var lines = File.ReadAllLines("input.txt");

            string uk = "uk";
            string us = "us";

            var sb = new StringBuilder();

            for (int i = 0; i < lines.Length; i += 2)
            {
                if (lines[i] == "stop" || lines[i + 1] == "stop")
                {
                    break;
                }

                var name = lines[i];
                var mail = lines[i + 1];

                if (mail.EndsWith(uk) || mail.EndsWith(us))
                {
                    continue;
                }

                sb.AppendLine($"{name} -> {mail}" + Environment.NewLine);
            }

            File.WriteAllText("output.txt", sb.ToString().TrimEnd());
        }
    }
}