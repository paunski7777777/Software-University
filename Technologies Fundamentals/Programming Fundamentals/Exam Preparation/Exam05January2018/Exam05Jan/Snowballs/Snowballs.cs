using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Snowballs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger snowBallValue = 0;
        BigInteger max = long.MinValue;
        string output = string.Empty;

        for (int i = 0; i < n; i++)
        {

            int snowBallSnow = int.Parse(Console.ReadLine());
            int snowBallTime = int.Parse(Console.ReadLine());
            int snowBallQuality = int.Parse(Console.ReadLine());

            snowBallValue = BigInteger.Pow((snowBallSnow / snowBallTime), snowBallQuality);

            if (snowBallValue >= max)
            {
                max = snowBallValue;
                output = $"{snowBallSnow} : {snowBallTime} = {snowBallValue} ({snowBallQuality})";
            }
        }

        Console.WriteLine(output);
    }
}

