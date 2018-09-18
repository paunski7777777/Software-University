namespace Employees.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Employees.Data;
    using Employees.Dtos;
    using Employees.Models;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto GetEmployeeDtoById(int id)
        {
            var employee = context.Employees.Find(id);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            context.SaveChanges();
        }
        public string SetBirthday(int id, DateTime date)
        {
            var employee = this.context.Employees.Find(id);

            employee.Birthday = date;

            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int id, string address)
        {
            var employee = this.context.Employees.Find(id);

            employee.Address = address;

            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }
        public EmployeePersonalDto GetPersonalInfoById(int id)
        {
            var employee = context.Employees.Find(id);

            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeeDto;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with {id} not found!");
            }

            return employee;
        }
        public void SetEmployeeManager(int employeeId, int managerId)
        {
            var employee = this.GetEmployeeById(employeeId);
            var manager = this.GetEmployeeById(managerId);

            if (manager.Manager != null && manager.Manager.Id == employee.Id)
            {
                throw new ArgumentException($"Employee with ID {employee.Id} is already manager of {manager.Id}!");
            }

            employee.Manager = manager;

            this.context.SaveChanges();
        }
        public string GetManagerInfo(int id)
        {
            var sb = new StringBuilder();

            var employee = this.GetEmployeeById(id);

            var managerDto = Mapper.Map<ManagerDto>(employee);

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeesToManage.Count}");

            foreach (var employeeDto in managerDto.EmployeesToManage)
            {
                sb.AppendLine($"    - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public ICollection<EmployeeDto> GetEmployeeDtosOlderThan(int age)
        {
            var employees = context.Employees
               .Where(e => e.Birthday != null
                           && Math.Floor((DateTime.Now - e.Birthday.Value).TotalDays / 365) > age)
               .Include(e => e.Manager)
               .ProjectTo<EmployeeDto>()
               .OrderByDescending(s => s.Salary)
               .ToList();

            return employees;
        }
    }
}