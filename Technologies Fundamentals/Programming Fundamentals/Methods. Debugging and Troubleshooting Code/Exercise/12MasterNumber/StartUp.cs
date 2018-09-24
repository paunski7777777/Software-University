namespace _12MasterNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsPalindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsPalindrome(int n)
        {
            string number = n.ToString();

            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] == number[number.Length - 1 - i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static bool SumOfDigits(int n)
        {
            string number = n.ToString();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += int.Parse(number[i].ToString());
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ContainsEvenDigit(int n)
        {
            string number = n.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                int rem = int.Parse(number[i].ToString());

                if (rem % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}