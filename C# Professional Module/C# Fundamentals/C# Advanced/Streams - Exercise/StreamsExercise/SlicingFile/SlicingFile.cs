using System;
using System.Collections.Generic;
using System.IO;

class SlicingFile
{
    static void Main()
    {
        string sourceFile = "../Resource/sliceMe.mp4";
        string destination = string.Empty;
        int parts = 5;

        Slice(sourceFile, destination, parts);

        var files = new List<string>
        {
            "Part - 0.mp4",
            "Part - 1.mp4",
            "Part - 2.mp4",
            "Part - 3.mp4",
            "Part - 4.mp4"
        };

        Assemble(files, destination);
    }

    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var reader = new FileStream(sourceFile, FileMode.Open))
        {
            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
            long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

            for (int i = 0; i < parts; i++)
            {
                long currentPieceSize = 0;

                destinationDirectory = destinationDirectory == string.Empty ? "./" : destinationDirectory;

                string currentPart = destinationDirectory + $"Part - {i}.{extension}";

                using (var writer = new FileStream(currentPart, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (reader.Read(buffer, 0, buffer.Length) == 4096)
                    {
                        writer.Write(buffer, 0, buffer.Length);
                        currentPieceSize += buffer.Length;

                        if (currentPieceSize >= pieceSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

        if (destinationDirectory == string.Empty)
        {
            destinationDirectory = "./";
        }

        if (destinationDirectory.EndsWith("/"))
        {
            destinationDirectory += "/";
        }

        string assembledFile = $"{destinationDirectory} Assambled.{extension}";

        using (var writer = new FileStream(assembledFile, FileMode.Create))
        {
            byte[] buffer = new byte[4096];

            foreach (var f in files)
            {
                using (var reader = new FileStream(f, FileMode.Open))
                {
                    while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                    {
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}

