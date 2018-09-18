using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = array[0];
        int s = array[1];
        int x = array[2];

        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        var queue = new Queue<int>();

        foreach (var l in list.Take(n).ToList())
        {
            queue.Enqueue(l);
        }

        for (int i = 0; i < s; i++)
        {
            queue.Dequeue();
        }

        if (queue.Contains(x))
        {
            Console.WriteLine("true");
        }
        else if (queue.Count < 1)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}

