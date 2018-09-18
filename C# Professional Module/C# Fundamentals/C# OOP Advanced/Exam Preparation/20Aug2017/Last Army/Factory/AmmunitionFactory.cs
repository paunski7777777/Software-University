using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .First(t => t.Name == ammunitionName);

        return (IAmmunition)Activator.CreateInstance(type);
    }
}