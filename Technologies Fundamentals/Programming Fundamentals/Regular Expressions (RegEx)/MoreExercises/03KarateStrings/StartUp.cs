namespace _03KarateStrings
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int punchStrenght = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    punchStrenght += int.Parse(input[i + 1].ToString());
                }
                else if (punchStrenght > 0)
                {
                    punchStrenght--;
                    continue;
                }

                sb.Append(input[i]);
            }

            Console.WriteLine(string.Join("", sb));
        }
    }
}