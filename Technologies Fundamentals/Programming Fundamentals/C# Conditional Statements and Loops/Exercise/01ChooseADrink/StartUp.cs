namespace _01ChooseADrink
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string proffesion = Console.ReadLine();

            if (proffesion == "Athlete")
            {
                Console.WriteLine("Water");
            }
            else if (proffesion == "Businessman" || proffesion == "Businesswoman")
            {
                Console.WriteLine("Coffee");
            }
            else if (proffesion == "SoftUni Student")
            {
                Console.WriteLine("Beer");
            }
            else
            {
                Console.WriteLine("Tea");
            }
        }
    }
}