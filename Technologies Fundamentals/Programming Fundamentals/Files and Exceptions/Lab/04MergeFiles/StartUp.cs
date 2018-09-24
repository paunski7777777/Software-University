namespace _04MergeFiles
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            string[] input1 = File.ReadAllText("FileOne.txt").Split();
            string[] input2 = File.ReadAllText("FileTwo.txt").Split('\r', '\n');

            File.WriteAllText("result.txt", "");

            for (int i = 0; i < input1.Length; i++)
            {
                File.AppendAllText("result.txt", input1[i] + "\r\n" + input2[i]);
            }
        }
    }
}