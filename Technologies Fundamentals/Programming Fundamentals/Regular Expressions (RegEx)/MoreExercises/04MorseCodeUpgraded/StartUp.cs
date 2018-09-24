namespace _04MorseCodeUpgraded
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split('|');

            string morse = string.Empty;
            int sum = 0;

            foreach (var i in input)
            {
                int count0 = i.Count(x => x == '0');
                int count1 = i.Count(x => x == '1');

                sum = count0 * 3 + count1 * 5;

                Regex sequence = new Regex(@"0{2,}|1{2,}");
                MatchCollection matches = sequence.Matches(i);

                foreach (Match m in matches)
                {
                    sum += m.Length;
                }

                morse += (char)sum;
            }

            Console.WriteLine(morse);
        }
    }
}