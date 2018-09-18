namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;
    using System;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = this.employeeService.GetPersonalInfoById(id);

            string birthday = "[no birthday specified]";

            if (employee.Birthday != null)
            {
                birthday = employee.Birthday.Value.ToString("dd-MM-yyyy");
            }
            
            string address = employee.Address ?? "[no address specified]";

            return $"ID: {id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}{Environment.NewLine}Birthday: {birthday}{Environment.NewLine}Address: {address}";
        }
    }
}
