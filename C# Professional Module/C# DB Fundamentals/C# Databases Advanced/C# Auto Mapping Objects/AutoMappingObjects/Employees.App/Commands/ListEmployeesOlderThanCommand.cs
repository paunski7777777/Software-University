namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;

    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var sb = new StringBuilder();

            int age = int.Parse(args[0]);

            var employees = this.employeeService.GetEmployeeDtosOlderThan(age);

            if (employees.Count == 0)
            {
                return $"No employees older than {age} years found!";
            }

            foreach (var employee in employees)
            {
                var managerName = "[no manager]";

                if (employee.Manager != null)
                {
                    managerName = employee.Manager.LastName;
                }

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {managerName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}