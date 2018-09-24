namespace _03RestaurantDiscount
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double price = 0;

            if (people <= 50)
            {
                string hall = "Small Hall";
                Console.WriteLine($"We can offer you the {hall}");
                if (package == "Normal")
                {
                    price = 2500 + 500 - ((2500 + 500) * 0.05);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Gold")
                {
                    price = 2500 + 750 - ((2500 + 750) * 0.10);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Platinum")
                {
                    price = 2500 + 1000 - ((2500 + 1000) * 0.15);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
            }

            else if (people > 50 && people <= 100)
            {
                string hall = "Terrace";
                Console.WriteLine($"We can offer you the {hall}");
                if (package == "Normal")
                {
                    price = 5000 + 500 - ((5000 + 500) * 0.05);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Gold")
                {
                    price = 5000 + 750 - ((5000 + 750) * 0.10);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Platinum")
                {
                    price = 5000 + 1000 - ((5000 + 1000) * 0.15);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
            }

            else if (people > 100 && people <= 120)
            {
                string hall = "Great Hall";
                Console.WriteLine($"We can offer you the {hall}");
                if (package == "Normal")
                {
                    price = 7500 + 500 - ((7500 + 500) * 0.05);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Gold")
                {
                    price = 7500 + 750 - ((7500 + 750) * 0.10);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
                else if (package == "Platinum")
                {
                    price = 7500 + 1000 - ((7500 + 1000) * 0.15);
                    Console.WriteLine($"The price per person is {(price / people):f2}$");
                }
            }

            else if (people > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}