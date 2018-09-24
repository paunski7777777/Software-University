namespace _02EmailMe
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] email = Console.ReadLine().Split('@');

            int before = email.First().Sum(x => x);
            int after = email.Last().Sum(x => x);

            if (before - after >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}