namespace Employees.App
{
    using AutoMapper;

    using Employees.Dtos;
    using Employees.Models;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeePersonalDto>();
        }
    }
}