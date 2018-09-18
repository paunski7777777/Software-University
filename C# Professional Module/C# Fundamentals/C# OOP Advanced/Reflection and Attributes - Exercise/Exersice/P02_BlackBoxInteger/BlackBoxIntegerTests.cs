namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);

            FieldInfo innerValue = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            Object instance = Activator.CreateInstance(classType, true);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split("_");
                string command = tokens[0];

                MethodInfo method = methods.First(m => m.Name == command);
                int value = int.Parse(tokens[1]);

                method.Invoke(instance, new object[] { value });

                Object result = innerValue.GetValue(instance);

                Console.WriteLine(result);
            }
        }
    }
}
