namespace _06SumBigNumbers
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();

            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }

            StringBuilder sb = new StringBuilder();

            int sum = 0;
            int num = 0;
            int rem = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sum = num1[i] - 48 + num2[i] - 48 + rem;
                num = sum % 10;
                sb.Append(num);
                rem = sum / 10;

                if (i == 0 && rem > 0)
                {
                    sb.Append(rem);
                }
            }

            Console.WriteLine(new string(sb.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray()));
        }
    }
}