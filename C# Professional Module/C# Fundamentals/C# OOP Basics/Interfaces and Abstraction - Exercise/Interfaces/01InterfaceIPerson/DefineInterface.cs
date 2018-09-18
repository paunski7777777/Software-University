using System;
public class DefineInterface
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birtdate = Console.ReadLine();

        IIdentifiable identifiable = new Citizen(name, age, id, birtdate);
        IBirthable birthable = new Citizen(name, age, id, birtdate);

        Console.WriteLine(identifiable.Id);
        Console.WriteLine(birthable.Birthdate);
    }
}

