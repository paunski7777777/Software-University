namespace _01Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var phonebook = new Dictionary<string, string>();

            while (input != "END")
            {
                var text = input.Split().ToArray();

                if (text[0] == "A")
                {
                    if (phonebook.ContainsKey(text[1]))
                    {
                        phonebook.Remove(text[1]);
                    }

                    phonebook.Add(text[1], text[2]);
                }
                else if (text[0] == "S")
                {
                    if (phonebook.ContainsKey(text[1]))
                    {

                        Console.WriteLine($"{text[1]} -> {phonebook[text[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {text[1]} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}