using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Files
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> files = new List<string>();

        for (int i = 0; i < n; i++)
        {
            files.Add(Console.ReadLine());
        }

        string input = Console.ReadLine();
        string[] filter = Regex.Split(input, " in ");
        string extension = "." + filter[0];
        string root = filter[1] + @"\";

        Dictionary<string, long> size = new Dictionary<string, long>();

        foreach (var f in files)
        {
            string[] fileAndSize = f.Split(';');
            long theSize = long.Parse(fileAndSize[1]);
            string path = fileAndSize[0];

            if (path.StartsWith(root) && path.EndsWith(extension))
            {
                string[] tokens = path.Split('\\');
                string name = tokens[tokens.Length - 1];
                size[name] = theSize;
            }
        }

        foreach (var fs in size.OrderByDescending(a => a.Value).ThenBy(b => b.Key))
        {
            Console.WriteLine($"{fs.Key} - {fs.Value} KB");
        }

        if (size.Count() == 0)
        {
            Console.WriteLine("No");
        }
    }
}

