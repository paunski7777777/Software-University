namespace _15BalancedBrackets
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string lastB = string.Empty;
            string balance = "BALANCED";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (lastB == "(")
                    {
                        balance = "UNBALANCED";
                    }

                    lastB = "(";
                }
                if (input == ")")
                {
                    if (lastB != "(")
                    {
                        balance = "UNBALANCED";
                    }

                    lastB = ")";
                }
            }
            if (lastB == "(")
            {
                balance = "UNBALANCED";
            }

            Console.WriteLine(balance);
        }
    }
}