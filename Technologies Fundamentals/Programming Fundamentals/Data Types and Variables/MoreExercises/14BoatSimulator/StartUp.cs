namespace _14BoatSimulator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char boat1 = char.Parse(Console.ReadLine());
            char boat2 = char.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int moves1 = 0;
            int moves2 = 0;

            for (int i = 0; i < n; i++)
            {
                string commands = Console.ReadLine();

                if (i % 2 != 0)
                {
                    moves1 += commands.Length;
                }
                else if (i % 2 == 0)
                {
                    moves2 += commands.Length;
                }

                if (commands == "UPGRADE")
                {
                    boat1 += (char)3;
                    boat2 += (char)3;
                }

                if (moves1 >= 50 || moves2 >= 50)
                {
                    break;
                }
            }

            if (moves1 > moves2)
            {
                Console.WriteLine(boat2);
            }
            else
            {
                Console.WriteLine(boat1);
            }
        }
    }
}