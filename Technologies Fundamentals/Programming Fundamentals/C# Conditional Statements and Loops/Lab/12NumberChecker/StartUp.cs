namespace _12NumberChecker
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}