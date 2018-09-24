namespace _07SentenceTheThief
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            long max = long.MinValue;
            long sentence = 1;

            for (int i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());

                if (type == "sbyte")
                {
                    if (id <= sbyte.MaxValue)
                    {
                        if (id >= max)
                        {
                            max = id;
                        }
                    }
                }
                else if (type == "int")
                {
                    if (id <= int.MaxValue)
                    {
                        if (id >= max)
                        {
                            max = id;
                        }
                    }
                }
                else if (type == "long")
                {
                    if (id <= long.MaxValue)
                    {
                        if (id >= max)
                        {
                            max = id;
                        }
                    }
                }
            }

            if (max > sbyte.MaxValue)
            {
                sentence = (max / 127) + 1;
            }
            else if (max < sbyte.MinValue)
            {
                sentence = (max / -128) + 1;
            }

            if (sentence > 1)
            {
                Console.WriteLine($"Prisoner with id {max} is sentenced to {sentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {max} is sentenced to {sentence} year");
            }
        }
    }
}