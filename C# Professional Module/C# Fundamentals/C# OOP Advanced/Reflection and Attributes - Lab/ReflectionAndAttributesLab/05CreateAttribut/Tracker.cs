using System;
using System.Linq;
using System.Reflection;
public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {

        }
    }
}
