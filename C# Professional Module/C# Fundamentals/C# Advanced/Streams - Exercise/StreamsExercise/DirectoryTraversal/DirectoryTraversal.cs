using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        var filesDictionary = new Dictionary<string, List<FileInfo>>();
        var files = Directory.GetFiles(path);

        foreach (var f in files)
        {
            var fileInfo = new FileInfo(f);
            var extension = fileInfo.Extension;

            if (!filesDictionary.ContainsKey(extension))
            {
                filesDictionary[extension] = new List<FileInfo>();
            }

            filesDictionary[extension].Add(fileInfo);
        }

        filesDictionary = filesDictionary
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = desktop + "/report.txt";

        using (var writer = new StreamWriter(fileName))
        {
            foreach (var kvp in filesDictionary)
            {
                string extension = kvp.Key;

                writer.WriteLine(extension);

                var fileInfos = kvp.Value.OrderByDescending(x => x.Length);

                foreach (var fi in fileInfos)
                {
                    double filesSize = (double)fi.Length / 1024;

                    writer.WriteLine($"--{fi.Name} - {filesSize:f3}kb");
                }
            }
        }
    }
}

