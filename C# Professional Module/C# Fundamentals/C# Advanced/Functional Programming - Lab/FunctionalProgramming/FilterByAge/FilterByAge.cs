using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FilterByAge
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var people = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            string[] input1 = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string name = input1[0];
            int personAge = int.Parse(input1[1]);

            people.Add(name, personAge);
        }

        string condition = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        var filter = GetFilter(condition, age);
        var printer = CreatePrinter(format);

        PrintResults(people, filter, printer);
    }

    private static void PrintResults(Dictionary<string, int> people, Func<int, bool> filter, Action<KeyValuePair<string, int>> printer)
    {
        foreach (var p in people)
        {
            if (filter(p.Value))
                printer(p);
        }
    }

    public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
    {
        switch (format)
        {
            case "name":
                return person => Console.WriteLine($"{person.Key}");
            case "age":
                return person => Console.WriteLine($"{person.Value}");
            case "name age":
                return person => Console.WriteLine($"{person.Key} - {person.Value}");
            default: return null;
        }
    }

    private static Func<int, bool> GetFilter(string condition, int age)
    {
        switch (condition)
        {
            case "younger": return x => x < age;
            case "older": return x => x >= age;
            default: return null;
        }
    }
}


