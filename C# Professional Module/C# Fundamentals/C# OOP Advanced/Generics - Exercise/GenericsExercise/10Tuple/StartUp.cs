using System;
public class StartUp
{
    public static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        string name1 = $"{input1[0]} {input1[1]}";
        string address = input1[2];

        var tuple1 = new Tuple<string, string>(name1, address);

        Console.WriteLine(tuple1);

        string[] input2 = Console.ReadLine().Split();
        string name2 = input2[0];
        int amount = int.Parse(input2[1]);

        var tuple2 = new Tuple<string, int>(name2, amount);

        Console.WriteLine(tuple2);

        string[] input3 = Console.ReadLine().Split();

        int integerValue = int.Parse(input3[0]);
        double doubleValue = double.Parse(input3[1]);

        var tuple3 = new Tuple<int, double>(integerValue, doubleValue);

        Console.WriteLine(tuple3);
    }
}

