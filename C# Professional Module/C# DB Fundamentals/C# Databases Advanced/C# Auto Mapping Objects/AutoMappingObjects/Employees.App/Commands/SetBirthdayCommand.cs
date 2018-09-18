namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.Services;

    using System;

    public class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            var employeeName = this.employeeService.SetBirthday(id, date);

            return $"{employeeName}'s birthday was set to {args[1]}";
        }
    }
}