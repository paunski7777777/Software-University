namespace _06DNA_Sequences
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int sum = int.Parse(Console.ReadLine());

            char sufix;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        if (i + j + k >= sum)
                        {
                            sufix = 'O';
                        }
                        else
                        {
                            sufix = 'X';
                        }

                        Console.Write($"{sufix}{i}{j}{k}{sufix} ".Replace("1", "A").Replace("2", "C").Replace("3", "G").Replace("4", "T"));
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}