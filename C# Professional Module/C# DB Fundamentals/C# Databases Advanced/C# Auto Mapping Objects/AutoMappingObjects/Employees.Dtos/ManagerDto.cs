using System.Collections.Generic;

namespace Employees.Dtos
{
    public class ManagerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeesToManageCount => this.EmployeesToManage.Count;
        public ICollection<EmployeeDto> EmployeesToManage { get; set; } = new List<EmployeeDto>();
    }
}