using System;
using System.IO;
class WriteToFile
{
    static void Main()
    {
        using (var reader = new StreamReader("WriteToFile.cs"))
        {
            using (var writer = new StreamWriter("reversed.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        writer.Write(line[i]);
                    }

                    writer.WriteLine();
                    line = reader.ReadLine();
                }
            }
        }
    }
}

