using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class AnonymousDownsite
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        BigInteger key = BigInteger.Parse(Console.ReadLine());

        var websites = new List<string>();
        decimal totalLoss = 0;
        int count = 0;
        BigInteger securityToken = 0;

        for (decimal i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] data = input.Split();

            string website = data[0];
            decimal visits = decimal.Parse(data[1]);
            decimal price = decimal.Parse(data[2]);

            websites.Add(website);
            totalLoss += visits * price;
            count++;
            securityToken = BigInteger.Pow(key, count);
        }

        foreach (var w in websites)
        {
            Console.WriteLine(w);
        }

        Console.WriteLine($"Total Loss: {totalLoss:f20}");
        Console.WriteLine($"Security Token: {securityToken}");
    }
}

