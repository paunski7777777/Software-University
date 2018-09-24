namespace _02NumberChecker
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                long number = long.Parse(Console.ReadLine());

                Console.WriteLine("integer");
            }
            catch (Exception)
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}