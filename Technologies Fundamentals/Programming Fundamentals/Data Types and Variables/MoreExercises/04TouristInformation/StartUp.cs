namespace _04TouristInformation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string unit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());

            double converted = 0;
            string newunit = " ";

            if (unit == "miles")
            {
                newunit = "kilometers";
                converted = 1.6 * value;

                Console.WriteLine($"{value} {unit} = {converted:f2} {newunit}");
            }
            else if (unit == "inches")
            {
                newunit = "centimeters";
                converted = 2.54 * value;

                Console.WriteLine($"{value} {unit} = {converted:f2} {newunit}");
            }
            else if (unit == "feet")
            {
                newunit = "centimeters";
                converted = 30 * value;

                Console.WriteLine($"{value} {unit} = {converted:f2} {newunit}");
            }
            else if (unit == "yards")
            {
                newunit = "meters";
                converted = 0.91 * value;

                Console.WriteLine($"{value} {unit} = {converted:f2} {newunit}");
            }
            else if (unit == "gallons")
            {
                newunit = "liters";
                converted = 3.8 * value;

                Console.WriteLine($"{value} {unit} = {converted:f2} {newunit}");
            }
        }
    }
}