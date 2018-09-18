namespace Employees.App
{
    using System;
    using System.Linq;

    internal class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        internal void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] commandTokens = input.Split();

                    string commandName = commandTokens[0];

                    string[] commadArgs = commandTokens.Skip(1).ToArray();

                    var command = CommandParser.Parse(this.serviceProvider, commandName);

                    var result = command.Execute(commadArgs);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}