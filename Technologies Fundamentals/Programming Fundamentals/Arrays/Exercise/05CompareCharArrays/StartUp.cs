namespace _05CompareCharArrays
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            char[] a = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] b = Console.ReadLine().Split().Select(char.Parse).ToArray();

            if (a[0] < b[0])
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
            else if (a[0] > b[0])
            {
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
            else
            {
                if (a.Length < b.Length)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                }
            }
        }
    }
}