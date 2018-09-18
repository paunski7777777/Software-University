using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        var reader = new StreamReader("text.txt");

        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;

                if (lineNumber % 2 == 0)
                {
                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
            }
        }
    }
}

