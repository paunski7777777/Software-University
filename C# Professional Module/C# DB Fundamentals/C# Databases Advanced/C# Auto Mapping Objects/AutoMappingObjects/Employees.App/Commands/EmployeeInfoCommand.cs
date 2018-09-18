namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = this.employeeService.GetEmployeeDtoById(id);

            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}";
        }
    }
}
