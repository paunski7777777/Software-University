using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader("ReadFile.cs");

        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                lineNumber++;
                Console.WriteLine($"Line {lineNumber}: {line}");
                line = reader.ReadLine();
            }
        }
    }
}

