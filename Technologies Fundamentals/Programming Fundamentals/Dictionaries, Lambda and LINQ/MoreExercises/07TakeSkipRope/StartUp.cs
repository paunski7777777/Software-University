namespace _07TakeSkipRope
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray().ToList();

            string result = string.Empty;

            var letters = input.Where(x => !char.IsDigit(x)).ToList();
            var digits = input.Where(x => char.IsDigit(x)).Select(x => int.Parse(x.ToString())).ToList();

            var take = digits.Where((x, i) => i % 2 == 0).ToList();
            var skip = digits.Where((x, i) => i % 2 != 0).ToList();

            foreach (var item in take.Zip(skip, Tuple.Create))
            {
                result += string.Join(null, letters.Select(x => x).Take(item.Item1));
                letters = letters.Skip(item.Item1 + item.Item2).ToList();
            }

            Console.WriteLine(result);
        }
    }
}