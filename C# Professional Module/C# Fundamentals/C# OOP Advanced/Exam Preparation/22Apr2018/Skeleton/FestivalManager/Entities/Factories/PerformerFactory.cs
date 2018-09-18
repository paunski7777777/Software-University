namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
    {
        public IPerformer CreatePerformer(string name, int age)
        {
            Type performerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(i => i.Name == nameof(Performer));

            return (IPerformer)Activator.CreateInstance(performerType, name, age);
        }
    }
}