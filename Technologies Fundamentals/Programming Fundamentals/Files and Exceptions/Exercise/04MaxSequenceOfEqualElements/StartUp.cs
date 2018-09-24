namespace _04MaxSequenceOfEqualElements
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

            int[] numbers = input3.Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;
            int max = 0;
            int pos = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[max])
                {
                    pos++;

                    if (pos > len)
                    {
                        len = pos;
                        start = max;
                    }
                }
                else
                {
                    pos = 1;
                    max = i;
                }
            }

            for (int i = start; i < start + len; i++)
            {
                // File.AppendAllText("output.txt", $"{numbers[i].ToString() + " "}");
                // File.AppendAllText("output2.txt", $"{numbers[i].ToString() + " "}");
                File.AppendAllText("output3.txt", $"{numbers[i].ToString() + " "}");
            }
        }
    }
}