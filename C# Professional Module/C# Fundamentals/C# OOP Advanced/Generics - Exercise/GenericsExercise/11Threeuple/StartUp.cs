using System;
public class StartUp
{
    public static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        string name1 = $"{input1[0]} {input1[1]}";
        string address = input1[2];
        string town = input1[3];

        var tuple1 = new Tuple<string, string, string>(name1, address, town);

        Console.WriteLine(tuple1);

        string[] input2 = Console.ReadLine().Split();
        string name2 = input2[0];
        int amount = int.Parse(input2[1]);
        string condition;

        if (input2[2] == "drunk")
        {
            condition = "True";
        }
        else
        {
            condition = "False";
        }

        var tuple2 = new Tuple<string, int, string>(name2, amount, condition);

        Console.WriteLine(tuple2);

        string[] input3 = Console.ReadLine().Split();

        string name3 = input3[0];
        double accountBalance = double.Parse(input3[1]);
        string bankName = input3[2];


        var tuple3 = new Tuple<string, double, string>(name3, accountBalance, bankName);

        Console.WriteLine(tuple3);
    }
}
