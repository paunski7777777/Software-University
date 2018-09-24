namespace _05BooleanVariable
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            if (text == "True")
            {
                Convert.ToBoolean(text);
                Console.WriteLine("Yes");
            }
            else if (text == "False")
            {
                Convert.ToBoolean(text);
                Console.WriteLine("No");
            }
        }
    }
}