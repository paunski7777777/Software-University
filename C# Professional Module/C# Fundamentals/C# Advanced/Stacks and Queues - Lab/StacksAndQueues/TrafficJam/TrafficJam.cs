using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrafficJam
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        var queue = new Queue<string>();
        int count = 0;

        while (input != "end")
        {
            if (input == "green")
            {
                int passingCars = Math.Min(queue.Count, n);

                for (int i = 0; i < passingCars; i++)
                {
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                    count++;
                }
            }
            else
            {
                queue.Enqueue(input);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine($"{count} cars passed the crossroads.");
    }
}

