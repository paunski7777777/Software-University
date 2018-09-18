using P02_DatabaseFirst.Data;
using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var context = new SoftUniContext();

        using (context)
        {
            var employees = context.Employees
                .Where(d => d.DepartmentId == 6)
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            string departmentName = context.Departments.FirstOrDefault(d => d.Name == "Research and Development").Name;

            employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} from {departmentName} - ${e.Salary:f2}"));
        }
    }
}