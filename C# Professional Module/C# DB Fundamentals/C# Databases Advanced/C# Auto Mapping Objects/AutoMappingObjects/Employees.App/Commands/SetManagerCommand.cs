namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;

    public class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);

            this.employeeService.SetEmployeeManager(employeeId, managerId);

            return $"Employee with ID {managerId} is a manager of employee with ID {employeeId}.";
        }
    }
}