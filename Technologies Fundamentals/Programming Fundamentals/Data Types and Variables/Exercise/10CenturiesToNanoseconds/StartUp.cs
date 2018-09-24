namespace _10CenturiesToNanoseconds
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            decimal minutes = hours * 60M;
            decimal seconds = minutes * 60M;
            decimal milliseconds = seconds * 1000M;
            decimal microseconds = milliseconds * 1000;
            decimal nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}