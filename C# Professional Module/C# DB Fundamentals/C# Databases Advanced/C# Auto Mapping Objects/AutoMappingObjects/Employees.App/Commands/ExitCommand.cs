namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;

    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}