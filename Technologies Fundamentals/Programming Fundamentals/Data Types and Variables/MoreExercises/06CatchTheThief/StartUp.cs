namespace _06CatchTheThief
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            long max = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                long number = long.Parse(Console.ReadLine());

                if (type == "sbyte")
                {
                    if (number >= -128 && number <= 127)
                    {
                        if (number > max)
                        {
                            max = number;
                        }
                    }
                }
                else if (type == "int")
                {
                    if (number >= -2147483648 && number <= 2147483647)
                    {
                        if (number > max)
                        {
                            max = number;
                        }
                    }
                }
                else if (type == "long")
                {
                    if (number >= -9223372036854775808 && number <= 9223372036854775807)
                    {
                        if (number > max)
                        {
                            max = number;
                        }
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}