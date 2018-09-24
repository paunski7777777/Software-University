namespace _17PrintPartOfASCIItable
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int last = int.Parse(Console.ReadLine());

            for (int i = first; i <= last; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}