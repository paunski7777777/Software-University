using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class HornetComm
{
    static void Main()
    {
        string messsageRegex = @"^([\d+]+) <-> ([0-9a-zA-Z]+)$";
        string broadcastRegex = @"^([\D]+) <-> ([0-9a-zA-Z]+)$";

        Regex message = new Regex(messsageRegex);
        Regex broadcast = new Regex(broadcastRegex);

        string input = Console.ReadLine();

        List<string> messages = new List<string>();
        List<string> broadcasts = new List<string>();

        while (input != "Hornet is Green")
        {
            string[] tokens = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);

            if (message.IsMatch(input))
            {
                messages.Add($"{string.Join("", tokens[0].ToCharArray().Reverse())} -> {tokens[1]}");
            }

            if (broadcast.IsMatch(input))
            {
                StringBuilder sb = new StringBuilder();

                foreach (char ch in tokens[1])
                {
                    if (char.IsLower(ch))
                    {
                        sb.Append(Char.ToUpper(ch));
                        continue;
                    }

                    if (char.IsUpper(ch))
                    {
                        sb.Append(Char.ToLower(ch));
                        continue;
                    }

                    sb.Append(ch);
                }

                broadcasts.Add($"{sb.ToString()} -> {tokens[0]}");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine("Broadcasts:");
        if (broadcasts.Count != 0)
        {
            foreach (var b in broadcasts)
            {
                Console.WriteLine(b);
            }
        }
        else
        {
            Console.WriteLine("None");
        }

        Console.WriteLine("Messages:");
        if (messages.Count != 0)
        {
            foreach (var m in messages)
            {
                Console.WriteLine(m);
            }
        }
        else
        {
            Console.WriteLine("None");
        }
    }
}

