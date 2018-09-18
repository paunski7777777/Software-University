using System;
public class StartUp
{
    public static void Main()
    {
        INameChangeable dispatcher = new Dispatcher("Pesho");
        INameChangeHandler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            dispatcher.Name = input;
        }
    }
}
