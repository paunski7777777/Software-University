using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        using (var reader = new StreamReader("text.txt"))
        {
            using (var writer = new StreamWriter("output.txt"))
            {
                string line = reader.ReadLine();
                int count = 0;

                while (line != null)
                {
                    count++;
                    writer.WriteLine($"Line {count}: {line}");

                    line = reader.ReadLine();
                }
            }
        }
    }
}

