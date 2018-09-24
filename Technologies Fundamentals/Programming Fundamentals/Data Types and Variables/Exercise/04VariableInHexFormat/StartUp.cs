namespace _04VariableInHexFormat
{
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int n = 0;

            if (input.StartsWith("0x"))
            {
                n = Int32.Parse(input.Substring(2), NumberStyles.HexNumber);
            }
            else
            {
                n = Int32.Parse(input);
            }

            Console.WriteLine(n);
        }
    }
}