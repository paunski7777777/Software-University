using System;
using System.Linq;

class CryptoMaster
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int total = 0;

        for (int step = 1; step < numbers.Length; step++)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                int currentIndex = index;
                int nextIndex = (index + step) % numbers.Length;
                int currentTotal = 1;

                while (numbers[currentIndex] < numbers[nextIndex])
                {
                    currentIndex = nextIndex;
                    nextIndex = (nextIndex + step) % numbers.Length;
                    currentTotal++;
                }

                if (currentTotal > total)
                {
                    total = currentTotal;
                }
            }
        }

        Console.WriteLine(total);
    }
}

