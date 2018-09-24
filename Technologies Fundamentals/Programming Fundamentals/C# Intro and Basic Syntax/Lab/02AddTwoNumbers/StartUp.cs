namespace _02AddTwoNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int sum = a + b;

            Console.WriteLine($"{a} + {b} = {sum}");
        }
    }
}