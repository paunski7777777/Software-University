namespace _06FoldAndSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = arr.Length / 4;

            int[] row1Left = arr.Take(k).Reverse().ToArray();
            int[] row1Right = arr.Reverse().Take(k).ToArray();
            int[] row1 = row1Left.Concat(row1Right).ToArray();
            int[] row2 = arr.Skip(k).Take(k * 2).ToArray();

            var result = row1.Select((x, index) => x + row2[index]);

            Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}