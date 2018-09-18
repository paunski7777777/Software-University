namespace Employees.Dtos
{
    using Employees.Models;

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Employee Manager { get; set; }

        public EmployeeDto() { }
        public EmployeeDto(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }
    }
}