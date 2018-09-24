namespace _09CountTheIntegers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int count = 0;

            for (int i = 0; i <= 100; i++)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    count++;
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}