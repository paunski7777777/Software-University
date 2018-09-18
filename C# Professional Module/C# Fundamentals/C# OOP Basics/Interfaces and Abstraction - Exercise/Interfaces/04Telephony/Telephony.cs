using System;
public class Telephony
{
    public static void Main()
    {
        Call();
        Browse();
    }

    private static void Browse()
    {
        string[] urls = Console.ReadLine().Split();
        IBrowsable browsable = new Smartphone();
        foreach (var url in urls)
        {
            Console.WriteLine(browsable.Browsing(url));
        }
    }

    private static void Call()
    {
        string[] numbers = Console.ReadLine().Split();
        ICallable callable = new Smartphone();
        foreach (var number in numbers)
        {
            Console.WriteLine(callable.Calling(number));
        }
    }
}

