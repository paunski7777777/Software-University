using System;
public class PadawanEquipment
{
    public static void Main()
    {
        decimal money = decimal.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        decimal lightsabersPrice = decimal.Parse(Console.ReadLine());
        decimal robesPrice = decimal.Parse(Console.ReadLine());
        decimal beltsPrice = decimal.Parse(Console.ReadLine());

        decimal lightsabers = lightsabersPrice * (students + (decimal)Math.Ceiling(students * 0.1));
        decimal robes = robesPrice * students;
        decimal belts = students * beltsPrice - ((students / 6) * beltsPrice);

        decimal total = lightsabers + robes + belts;

        if (money >= total)
        {
            Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivan Cho will need {total - money:f2}lv more.");
        }
    }
}

