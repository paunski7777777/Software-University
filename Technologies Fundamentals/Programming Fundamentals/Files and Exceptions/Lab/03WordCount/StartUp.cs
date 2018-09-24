namespace _03WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = File.ReadAllText("words.txt").ToLower().Split();
            string[] text = File.ReadAllText("text.txt")
                                .ToLower()
                                .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' },
                                 StringSplitOptions.RemoveEmptyEntries);

            var count = new Dictionary<string, int>();

            foreach (string word in words)
            {
                count[word] = 0;
            }

            foreach (string word in text)
            {
                if (count.ContainsKey(word))
                {
                    count[word]++;
                }
            }

            count = count.OrderByDescending(w => w.Value).ToDictionary(x => x.Key, x => x.Value);

            File.WriteAllText("result.txt", "");

            foreach (KeyValuePair<string, int> c in count)
            {
                File.AppendAllText("result.txt", $"{c.Key} - {c.Value}\r\n");
            }
        }
    }
}