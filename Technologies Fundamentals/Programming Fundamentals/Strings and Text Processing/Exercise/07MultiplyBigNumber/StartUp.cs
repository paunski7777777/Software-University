namespace _07MultiplyBigNumber
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string num1 = Console.ReadLine().TrimStart('0');
            long num2 = long.Parse(Console.ReadLine());

            if (num1 == "0" || num2 == 0 || num1 == "")
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();

            long sum = 0;
            long num = 0;
            long rem = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sum = (long)(long.Parse(num1[i].ToString()) * num2 + num);
                num = sum / 10;
                rem = sum % 10;
                sb.Append(rem);

                if (i == 0 && num != 0)
                {
                    sb.Append(num);
                }
            }

            char[] sb2 = sb.ToString().ToCharArray();
            Array.Reverse(sb2);
            Console.WriteLine(new string(sb2));
        }
    }
}