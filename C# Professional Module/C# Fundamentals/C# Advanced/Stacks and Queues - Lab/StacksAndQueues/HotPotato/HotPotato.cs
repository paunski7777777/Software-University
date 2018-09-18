using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HotPotato
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        var queue = new Queue<string>(input);

        while (queue.Count != 1)
        {
            for (int i = 1; i < n; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            Console.WriteLine($"Removed {queue.Dequeue()}");
        }
        
        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}

