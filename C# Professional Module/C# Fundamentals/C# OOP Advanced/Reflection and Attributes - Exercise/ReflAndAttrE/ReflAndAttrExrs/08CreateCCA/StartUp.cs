using System.Linq;

[CustomClass("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class StartUp
{
    public static void Main()
    {
        CustomClassAttribute attribute = (CustomClassAttribute)typeof(StartUp).GetCustomAttributes(false).FirstOrDefault();
        CommandInterpreter commandInterpreter = new CommandInterpreter(attribute);
        commandInterpreter.Run();
    }
}