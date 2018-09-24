using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Snowmen
{
    static void Main()
    {
        var snowmen = Console.ReadLine().Split().Select(int.Parse).ToList();
        var unableToAttack = new HashSet<int>();

        while (snowmen.Count > 1)
        {
            for (int i = 0; i < snowmen.Count; i++)
            {
                if (!unableToAttack.Contains(i))
                {
                    int attacker = i;
                    int target = snowmen[i];

                    if (target >= snowmen.Count)
                    {
                        target %= snowmen.Count;
                    }

                    if (attacker == target)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        unableToAttack.Add(attacker);
                    }

                    else if (Math.Abs(attacker - target) % 2 == 0)
                    {

                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        unableToAttack.Add(target);
                    }

                    else
                    {
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        unableToAttack.Add(attacker);
                    }


                    if (snowmen.Count - unableToAttack.Count == 1)
                    {
                        break;
                    }
                }

            }

            foreach (var u in unableToAttack)
            {
                snowmen[u] = -1;
            }

            unableToAttack.Clear();
            snowmen = snowmen.Where(x => x != -1).ToList();
        }
    }
}


