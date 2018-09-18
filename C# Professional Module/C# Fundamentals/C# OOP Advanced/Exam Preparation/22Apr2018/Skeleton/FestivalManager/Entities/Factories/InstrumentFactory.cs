namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type instrumentType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(i => i.Name == type);

            return (IInstrument)Activator.CreateInstance(instrumentType);
        }
    }
}