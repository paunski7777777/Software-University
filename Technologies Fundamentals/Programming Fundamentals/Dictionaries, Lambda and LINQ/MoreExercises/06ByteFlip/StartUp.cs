namespace _06ByteFlip
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                        .Split()
                        .Where(x => x.Length == 2)
                        .Select(x => new string(x.Reverse().ToArray()))
                        .Select(x => Convert.ToChar(Convert.ToInt32(x, 16)))
                        .Reverse()
                        .ToList();

            Console.WriteLine(string.Join(null, input));
        }
    }
}