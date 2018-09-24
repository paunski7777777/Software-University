using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class NetherRealms
{
    static void Main()
    {
        var demons = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(Demon.Parse).OrderBy(x => x.Name).ToList();

        foreach (var d in demons)
        {
            Console.WriteLine($"{d.Name} - {d.Health} health, {d.Damage:f2} damage");
        }
    }
}

class Demon
{
    public string Name { get; set; }
    public decimal Health { get; set; }
    public decimal Damage { get; set; }

    internal static Demon Parse(string demonName)
    {
        string name = demonName;

        Regex healthPattern = new Regex(@"[^\d\-*\/\.]");
        Regex damagePattern = new Regex(@"-?\d+(?:\.\d+)?");

        var health = healthPattern.Matches(demonName)
            .Cast<Match>()
            .Select(x => (int)char.Parse(x.Value))
            .Sum();

        var damage = damagePattern.Matches(demonName)
            .Cast<Match>()
            .Select(x => decimal.Parse(x.Value))
            .Sum();

        var multiply = demonName.Count(x => x == '*');
        var divide = demonName.Count(x => x == '/');

        damage *= (int)Math.Pow(2, multiply);
        damage /= (int)Math.Pow(2, divide);

        Demon demon = new Demon
        {
            Name = name,
            Health = health,
            Damage = damage
        };

        return demon;
    }
}

