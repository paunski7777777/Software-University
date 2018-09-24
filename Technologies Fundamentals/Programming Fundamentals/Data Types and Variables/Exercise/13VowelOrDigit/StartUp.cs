namespace _13VowelOrDigit
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char txt = char.Parse(Console.ReadLine());

            if (txt == 'a' || txt == 'o' || txt == 'e' || txt == 'i' || txt == 'u' || txt == 'y')
            {
                Console.WriteLine("vowel");
            }
            else if (char.IsNumber(txt))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}