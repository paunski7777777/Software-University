using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class KeyRevolver
{
    static void Main()
    {
        int priceOfBullet = int.Parse(Console.ReadLine());
        int sizeOfGunBarrel = int.Parse(Console.ReadLine());
        var bullets = Console.ReadLine().Split().Select(int.Parse).ToList();
        var locks = Console.ReadLine().Split().Select(int.Parse).ToList();
        int valueOfIntelligence = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();
        var queue = new Queue<int>();

        int money = 0;
        int count = 0;
        int size = sizeOfGunBarrel;

        for (int i = 0; i < bullets.Count; i++)
        {
            stack.Push(bullets[i]);
        }
        for (int i = 0; i < locks.Count; i++)
        {
            queue.Enqueue(locks[i]);
        }

        while (queue.Count > 0 && stack.Count > 0)
        {
            if (stack.Peek() <= queue.Peek())
            {
                stack.Pop();
                queue.Dequeue();

                size--;
                count++;

                Console.WriteLine("Bang!");
            }

            else if (stack.Peek() > queue.Peek())
            {
                stack.Pop();

                size--;
                count++;

                Console.WriteLine("Ping!");
            }

            if (size == 0 && stack.Count > 0)
            {
                Console.WriteLine("Reloading!");

                size += sizeOfGunBarrel;
            }
        }

        money = count * priceOfBullet;

        if (queue.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
        }
        else
        {
            Console.WriteLine($"{stack.Count} bullets left. Earned ${valueOfIntelligence - money}");
        }
    }
}

