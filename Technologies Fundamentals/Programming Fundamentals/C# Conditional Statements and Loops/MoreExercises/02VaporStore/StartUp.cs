namespace _02VaporStore
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double balance = double.Parse(Console.ReadLine());

            double outfall4 = 39.99;
            double csgo = 15.99;
            double zplinterzell = 19.99;
            double honored2 = 59.99;
            double roverwatch = 29.99;
            double roverwatchoriginsedition = 39.99;

            double total = 0;

            while (balance > 0)
            {
                string game = Console.ReadLine();

                if (game == "OutFall 4")
                {
                    if (balance < outfall4)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= outfall4;
                        total += outfall4;

                        Console.WriteLine("Bought OutFall 4");
                    }
                }
                else if (game == "CS: OG")
                {
                    if (balance < csgo)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= csgo;
                        total += csgo;

                        Console.WriteLine("Bought CS: OG");
                    }
                }
                else if (game == "Zplinter Zell")
                {
                    if (balance < zplinterzell)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= zplinterzell;
                        total += zplinterzell;

                        Console.WriteLine("Bought Zplinter Zell");
                    }
                }
                else if (game == "Honored 2")
                {
                    if (balance < honored2)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= honored2;
                        total += honored2;

                        Console.WriteLine("Bought Honored 2");
                    }
                }
                else if (game == "RoverWatch")
                {
                    if (balance < roverwatch)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= roverwatch;
                        total += roverwatch;

                        Console.WriteLine("Bought RoverWatch");
                    }
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    if (balance < roverwatchoriginsedition)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= roverwatchoriginsedition;
                        total += roverwatchoriginsedition;

                        Console.WriteLine("Bought RoverWatch Origins Edition");
                    }
                }
                else if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${total:f2}. Remaining: ${balance:f2}");
                    break;
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }

            if (balance <= 0)
            {
                Console.WriteLine("Out of money!");
            }
        }
    }
}