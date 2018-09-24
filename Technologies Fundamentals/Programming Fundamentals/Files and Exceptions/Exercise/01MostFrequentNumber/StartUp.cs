namespace _01MostFrequentNumber
{
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // var input = File.ReadAllText("input.txt");
            // var input2 = File.ReadAllText("input2.txt");
            var input3 = File.ReadAllText("input3.txt");

            // ushort[] numbers = input.Split().Select(ushort.Parse).ToArray();
            // ushort[] numbers = input2.Split().Select(ushort.Parse).ToArray();
            ushort[] numbers = input3.Split().Select(ushort.Parse).ToArray();

            int[] count = new int[65535];

            foreach (ushort i in numbers)
            {
                count[i]++;
            }

            int mostF = count.Max();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (count[numbers[i]] == mostF)
                {
                    // File.AppendAllText("output.txt", numbers[i].ToString());
                    // File.AppendAllText("output2.txt", numbers[i].ToString());
                    File.AppendAllText("output3.txt", numbers[i].ToString());
                    return;
                }
            }
        }
    }
}