using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        return command.Execute();
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(ct => ct.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }
        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo constructor = commandType.GetConstructors().First();
        ParameterInfo[] parametersInfo = constructor.GetParameters();
        object[] parameters = new object[parametersInfo.Length];

        for (int i = 0; i < parametersInfo.Length; i++)
        {
            Type paramType = parametersInfo[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args;
            }
            else
            {
                PropertyInfo paramInfo = this.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, parameters);

        return command;
    }
}