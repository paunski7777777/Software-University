namespace _02ManipulateArray
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());

            string[] reverse = new string[0];
            string[] distict = new string[0];
            string[] replace = new string[0];

            for (int i = 0; i < n; i++)
            {
                string commands = Console.ReadLine();

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
                else
                {
                    replace = commands.Split().ToArray();

                    int index = int.Parse(replace[1]);
                    array[index] = replace[2];
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}