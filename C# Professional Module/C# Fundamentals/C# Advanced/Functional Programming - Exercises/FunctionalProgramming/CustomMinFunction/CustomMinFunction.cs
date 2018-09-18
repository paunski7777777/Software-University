using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CustomMinFunction
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        Func<List<int>, int> getMin = GetMin;
        Console.WriteLine(GetMin(numbers));
    }

    private static int GetMin(List<int> numbers)
    {
        return numbers.Min();
    }
}

