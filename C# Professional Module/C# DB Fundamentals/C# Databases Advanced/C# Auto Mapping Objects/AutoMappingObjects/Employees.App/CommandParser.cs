namespace Employees.App
{
    using Employees.App.Commands.Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    internal class CommandParser
    {
        public static ICommand Parse(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            var commandType = commandTypes.
                SingleOrDefault(t => t.Name.ToLower() == $"{commandName.ToLower()}command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constuctor = commandType.GetConstructors()
                .FirstOrDefault();

            var constructorParams = constuctor.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var constructorArgs = constructorParams
                .Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constuctor.Invoke(constructorArgs);

            return command;
        }
    }
}