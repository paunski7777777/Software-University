namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;

    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);

            return this.employeeService.GetManagerInfo(employeeId);
        }
    }
}