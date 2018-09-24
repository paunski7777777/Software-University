namespace _03EqualSums
{
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // string input = File.ReadAllText("input.txt");
            // string input2 = File.ReadAllText("input2.txt");
            // string input3 = File.ReadAllText("input3.txt");
            // string input4 = File.ReadAllText("input4.txt");
            string input5 = File.ReadAllText("input5.txt");

            // int[] numbers = input.Split().Select(int.Parse).ToArray();
            // int[] numbers = input2.Split().Select(int.Parse).ToArray();
            // int[] numbers = input3.Split().Select(int.Parse).ToArray();
            // int[] numbers = input4.Split().Select(int.Parse).ToArray();
            int[] numbers = input5.Split().Select(int.Parse).ToArray();

            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int[] left = numbers.Take(i).ToArray();
                int[] right = numbers.Skip(i + 1).ToArray();

                if (left.Sum() == right.Sum())
                {
                    // File.AppendAllText("output.txt", i.ToString());
                    // File.AppendAllText("output2.txt", i.ToString());
                    //  File.AppendAllText("output3.txt", i.ToString());
                    // File.AppendAllText("output4.txt", i.ToString());
                    File.AppendAllText("output5.txt", i.ToString());

                    isEqual = true;
                    break;
                }
            }

            if (!isEqual)
            {
                // File.AppendAllText("output.txt", "no");
                // File.AppendAllText("output2.txt", "no");
                // File.AppendAllText("output3.txt", "no");
                // File.AppendAllText("output4.txt", "no");
                File.AppendAllText("output5.txt", "no");
            }
        }
    }
}