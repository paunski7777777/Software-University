namespace _08GreaterOfTwoValues
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(n, m));
            }
            else if (type == "char")
            {
                char n = char.Parse(Console.ReadLine());
                char m = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMax2(n, m));
            }
            else if (type == "string")
            {
                string n = Console.ReadLine();
                string m = Console.ReadLine();

                Console.WriteLine(GetMax3(n, m));
            }
        }

        private static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static char GetMax2(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static string GetMax3(string a, string b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}