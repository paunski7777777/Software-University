namespace _02PhonebookUpgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var phonebook = new SortedDictionary<string, string>();

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
                else if (text[0] == "ListAll")
                {
                    foreach (var num in phonebook)
                    {
                        Console.WriteLine($"{num.Key} -> {num.Value}");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}