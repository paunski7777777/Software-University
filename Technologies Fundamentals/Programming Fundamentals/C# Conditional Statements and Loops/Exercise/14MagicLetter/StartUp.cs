namespace _14MagicLetter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string skip = Console.ReadLine();

            for (char i = first; i <= second; i++)
            {
                for (char j = first; j <= second; j++)
                {
                    for (char k = first; k <= second; k++)
                    {
                        string result = $"{i}{j}{k}";

                        if (!result.Contains(skip))
                        {
                            Console.Write(result + " ");
                        }
                    }
                }
            }
        }
    }
}