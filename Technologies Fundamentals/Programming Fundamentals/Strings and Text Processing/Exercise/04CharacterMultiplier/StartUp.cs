namespace _04CharacterMultiplier
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string s1 = input[0];
            string s2 = input[1];

            byte[] asciiBytes1 = Encoding.ASCII.GetBytes(s1);
            byte[] asciiBytes2 = Encoding.ASCII.GetBytes(s2);

            int min = Math.Min(s1.Length, s2.Length);
            int max = Math.Max(s1.Length, s2.Length);

            int sum = 0;

            for (int i = 0; i < min; i++)
            {
                sum += asciiBytes1[i] * asciiBytes2[i];
            }

            if (s1.Length < s2.Length)
            {
                for (int i = min; i < max; i++)
                {
                    sum += asciiBytes2[i];
                }
            }
            else
            {
                for (int j = min; j < max; j++)
                {
                    sum += asciiBytes1[j];
                }
            }

            Console.WriteLine(sum);
        }
    }
}