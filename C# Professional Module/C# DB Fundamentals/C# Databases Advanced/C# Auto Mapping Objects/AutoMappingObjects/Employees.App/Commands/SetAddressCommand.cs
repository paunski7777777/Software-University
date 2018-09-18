namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1));

            var employeeName = this.employeeService.SetAddress(id, address);

            return $"{employeeName}'s address was set to {address}";
        }
    }
}