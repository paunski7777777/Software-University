using System;
using System.Collections.Generic;

class CubicAltirelly
{
    static void Main()
    {
        int capacity = int.Parse(Console.ReadLine());

        var bunkers = new Queue<string>();
        var weapons = new Queue<int>();

        int leftCapacity = capacity;

        string input;
        while ((input = Console.ReadLine()) != "Bunker Revision")
        {
            string[] tokens = input.Split();

            foreach (var item in tokens)
            {
                int weapon;
                bool isDigit = int.TryParse(item, out weapon);

                if (!isDigit)
                {
                    bunkers.Enqueue(item);
                }
                else
                {
                    bool isSaved = false;

                    while (bunkers.Count > 1)
                    {
                        if (leftCapacity >= weapon)
                        {
                            weapons.Enqueue(weapon);
                            leftCapacity -= weapon;
                            isSaved = true;
                            break;
                        }

                        if (weapons.Count == 0)
                        {
                            Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                        }
                        else
                        {
                            Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                        }

                        weapons.Clear();
                        leftCapacity = capacity;
                    }

                    if (!isSaved)
                    {
                        if (weapon <= capacity)
                        {
                            while (leftCapacity < weapon)
                            {
                                leftCapacity += weapons.Dequeue();
                            }

                            weapons.Enqueue(weapon);
                            leftCapacity -= weapon;
                        }
                    }
                }
            }
        }
    }
}

