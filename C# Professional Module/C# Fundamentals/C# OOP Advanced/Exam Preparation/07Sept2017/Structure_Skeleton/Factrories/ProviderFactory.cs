using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        string type = args[1];
        int id = int.Parse(args[2]);
        double energyOutput = double.Parse(args[3]);

        Type providerType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Provider");

        ConstructorInfo[] ctors = providerType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        IProvider provider = (IProvider)ctors[0].Invoke(new object[] { id, energyOutput });

        return provider;
    }
}