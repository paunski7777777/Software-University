namespace Employees.App.Commands.Contracts
{
    internal interface ICommand
    {
        string Execute(params string[] args);
    }
}