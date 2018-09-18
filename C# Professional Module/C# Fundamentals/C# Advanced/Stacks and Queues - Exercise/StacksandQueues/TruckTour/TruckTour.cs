using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var queue = new Queue<int[]>();

        for (int i = 0; i < n; i++)
        {
            int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
            queue.Enqueue(pump);
        }

        for (int i = 0; i < n - 1; i++)
        {
            int fuel = 0;
            bool isSolution = true;

            for (int j = 0; j < n; j++)
            {
                int[] currentPump = queue.Dequeue();
                fuel += currentPump[0] - currentPump[1];

                queue.Enqueue(currentPump);

                if (fuel < 0)
                {
                    i += j;
                    isSolution = false;
                    break;
                }
            }

            if (isSolution)
            {
                Console.WriteLine(i);
                Environment.Exit(0);
            }
        }
    }
}

