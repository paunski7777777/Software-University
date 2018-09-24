using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Message
{
    public string Msg { get; set; }
    public string DecryptedMessage { get; set; }

    public Message(string msg, string decrMsg)
    {
        this.Msg = msg;
        this.DecryptedMessage = decrMsg;
    }
}
class CubicMessages
{
    static Regex pattern = new Regex(@"^(\d+)(?<msg>[A-Za-z]+)([^A-Za-z]*)$");
    static void Main()
    {
        string input = Console.ReadLine();


        while (input != "Over!")
        {
            int length = int.Parse(Console.ReadLine());

            Message message = DecryptMessage(input, length);

            if (message != null)
            {
                Console.WriteLine($"{message.Msg} == {message.DecryptedMessage}");
            }

            input = Console.ReadLine();
        }
    }

    public static Message DecryptMessage(string input, int length)
    {
        Match match = pattern.Match(input);
        string message = match.Groups["msg"].Value;

        if (message.Length != length)
        {
            return null;
        }

        string result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                int index = input[i] - '0';

                if (index >= message.Length)
                {
                    result += " ";
                }
                else
                {
                    result += message[index];
                }
            }
        }

        return new Message(message, result);
    }
}

