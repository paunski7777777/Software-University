using System;
using System.Linq;
using System.Reflection;
using System.Text;
public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        foreach (FieldInfo field in classFields.Where(f => fieldNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        string result = sb.ToString().TrimEnd();
        return result;
    }
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        string result = sb.ToString().TrimEnd();
        return result;
    }
    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");

        Type classType = Type.GetType(className);

        string baseClassType = classType.BaseType.Name;
        sb.AppendLine($"Base Class: {baseClassType}");

        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        string result = sb.ToString().TrimEnd();
        return result;
    }
    public string CollectGettersAndSetters(string className)
    {
        var sb = new StringBuilder();

        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

