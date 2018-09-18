using P02_DatabaseFirst.Data;
using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var db = new SoftUniContext();

        using (db)
        {
            var departments = db.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    EmployeeCount = d.Employees.Count,
                    DepartmentName = d.Name,
                    Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d.Employees.Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                })
                .OrderBy(d => d.EmployeeCount)
                .ThenBy(d => d.DepartmentName)
                .ToList();

            foreach (var d in departments)
            {
                Console.WriteLine($"{d.DepartmentName} - {d.Manager}");
                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
                Console.WriteLine(new string('-', 10));
            }

        }
    }
}