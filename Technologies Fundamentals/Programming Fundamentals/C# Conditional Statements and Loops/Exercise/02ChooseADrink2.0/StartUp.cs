namespace _02ChooseADrink2._0
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string proffesion = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double water = 0.70;
            double coffee = 1.00;
            double beer = 1.70;
            double tea = 1.20;

            if (proffesion == "Athlete")
            {
                Console.WriteLine($"The {proffesion} has to pay {(water * quantity):f2}.");
            }
            else if (proffesion == "Businessman" || proffesion == "Businesswoman")
            {
                Console.WriteLine($"The {proffesion} has to pay {(coffee * quantity):f2}.");
            }
            else if (proffesion == "SoftUni Student")
            {
                Console.WriteLine($"The {proffesion} has to pay {(beer * quantity):f2}.");
            }
            else
            {
                Console.WriteLine($"The {proffesion} has to pay {(tea * quantity):f2}.");
            }
        }
    }
}