using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AnonymousThreat
{
    static void Main()
    {
        var elements = Console.ReadLine().Split().ToList();
        string input = Console.ReadLine();

        while (input != "3:1")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "merge")
            {
                int startIndex = int.Parse(tokens[1]);
                int endIndex = int.Parse(tokens[2]);

                elements = Merge(elements, startIndex, endIndex);
            }

            else if (command == "divide")
            {
                int index = int.Parse(tokens[1]);
                int parts = int.Parse(tokens[2]);

                elements = Divide(elements, index, parts);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", elements));
    }


    static int ChangeIndex(int index, int maxLength)
    {
        if (index < 0)
        {
            index = 0;
        }
        if (index >= maxLength)
        {
            index = maxLength - 1;
        }

        return index;
    }

    static List<string> Merge(List<string> elements, int startIndex, int endIndex)
    {
        startIndex = ChangeIndex(startIndex, elements.Count);
        endIndex = ChangeIndex(endIndex, elements.Count);

        var result = new List<string>();

        for (int i = 0; i < startIndex; i++)
        {
            result.Add(elements[i]);
        }

        var sb = new StringBuilder();

        for (int i = startIndex; i <= endIndex; i++)
        {
            sb.Append(elements[i]);
        }

        result.Add(sb.ToString());

        for (int i = endIndex + 1; i < elements.Count; i++)
        {
            result.Add(elements[i]);
        }

        return result;
    }

    static List<string> Divide(List<string> elements, int index, int parts)
    {
        string element = elements[index];
        int length = element.Length / parts;
        var result = new List<string>();

        for (int i = 0; i < parts; i++)
        {
            if (i == parts - 1)
            {
                result.Add(element.Substring(i * length));
            }
            else
            {
                result.Add(element.Substring(i * length, length));
            }
        }

        elements.RemoveAt(index);
        elements.InsertRange(index, result);

        return elements;
    }
}


