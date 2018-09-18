using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ActionPrint
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Action<string[]> printer = Print;
        printer(input);
    }

    public static void Print(string[] input)
    {
        foreach (var i in input)
        {
            Console.WriteLine(i);
        }
    }
}

