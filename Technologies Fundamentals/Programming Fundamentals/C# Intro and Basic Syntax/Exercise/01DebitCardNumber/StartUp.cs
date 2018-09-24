namespace _01DebitCardNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine($"{a:D4} {b:D4} {c:D4} {d:D4}");
        }
    }
}