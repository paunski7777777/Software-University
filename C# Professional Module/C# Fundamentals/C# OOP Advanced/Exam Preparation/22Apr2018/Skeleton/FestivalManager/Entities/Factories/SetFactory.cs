namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type setType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(s => s.Name == type);

            return (ISet)Activator.CreateInstance(setType, name);
        }
    }
}
