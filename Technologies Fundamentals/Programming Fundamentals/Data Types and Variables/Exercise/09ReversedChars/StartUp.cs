namespace _09ReversedChars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            Console.WriteLine($"{c}{b}{a}");
        }
    }
}