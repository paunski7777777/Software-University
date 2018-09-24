namespace _03SafeManipulation
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split().ToArray();

            string[] reverse = new string[0];
            string[] distict = new string[0];
            string[] replace = new string[0];

            for (int i = 1; i > 0; i++)
            {
                string commands = Console.ReadLine();
                replace = commands.Split().ToArray();

                if (commands == "Reverse")
                {
                    reverse = array.Reverse().ToArray();
                    array = reverse;
                }
                else if (commands == "Distinct")
                {
                    distict = array.Distinct().ToArray();
                    array = distict;
                }
                else if (replace[0] == "Replace")
                {
                    int index = int.Parse(replace[1]);

                    if (index > array.Length - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        array[index] = replace[2];
                    }
                }
                else if (commands == "END")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}