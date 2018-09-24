using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ladybugs
{
    static void Main()
    {
        int sizeField = int.Parse(Console.ReadLine());
        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string input = Console.ReadLine();
        int[] array = new int[sizeField];

        foreach (int i in indexes)
        {
            if (i >= 0 && i < sizeField)
            {
                array[i] = 1;
            }
        }

        while (input != "end")
        {
            string[] commands = input.Split();
            int ladyBugIndex = int.Parse(commands[0]);
            string direction = commands[1];
            int flyLength = int.Parse(commands[2]);

            if (ladyBugIndex < 0 || ladyBugIndex >= sizeField)
            {
                input = Console.ReadLine();
                continue;
            }
            if (array[ladyBugIndex] == 0)
            {
                input = Console.ReadLine();
                continue;
            }

            if (direction == "right")
            {
                if (ladyBugIndex + flyLength >= sizeField || ladyBugIndex + flyLength < 0)
                {
                    array[ladyBugIndex] = 0;
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    int distance = ladyBugIndex + flyLength;
                    array[ladyBugIndex] = 0;

                    while (ladyBugIndex < sizeField && ladyBugIndex >= 0 && distance < sizeField && distance >= 0)
                    {
                        if (array[distance] == 0)
                        {
                            array[distance] = 1;
                            break;
                        }
                        else
                        {
                            distance += flyLength;
                        }
                    }
                }
            }

            else if (direction == "left")
            {
                if (ladyBugIndex - flyLength >= sizeField || ladyBugIndex - flyLength < 0)
                {
                    array[ladyBugIndex] = 0;
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    int distance = ladyBugIndex - flyLength;
                    array[ladyBugIndex] = 0;

                    while (ladyBugIndex < sizeField && ladyBugIndex >= 0 && distance < sizeField && distance >= 0)
                    {
                        if (array[distance] == 0)
                        {
                            array[distance] = 1;
                            break;
                        }
                        else
                        {
                            distance -= flyLength;
                        }
                    }
                }
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", array));
    }
}


