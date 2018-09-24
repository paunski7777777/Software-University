namespace _11FiveDifferentNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (Math.Abs(a - b) < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = a; i <= b; i++)
                {
                    for (int j = a; j <= b; j++)
                    {
                        for (int k = a; k <= b; k++)
                        {
                            for (int l = a; l <= b; l++)
                            {
                                for (int m = a; m <= b; m++)
                                {
                                    if (j <= i || k <= j || l <= k || m <= l)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        Console.Write(i + " ");
                                        Console.Write(j + " ");
                                        Console.Write(k + " ");
                                        Console.Write(l + " ");
                                        Console.WriteLine(m);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}