namespace _02MatchPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string phoneNumbers = Console.ReadLine();

            string regex = @"\+359( |-)+2\1\d{3}\1\d{4}\b";

            MatchCollection matched = Regex.Matches(phoneNumbers, regex);

            List<string> phonebook = new List<string>();

            foreach (Match number in matched)
            {
                phonebook.Add(number.Value);
            }

            Console.WriteLine(string.Join(", ", phonebook));
        }
    }
}