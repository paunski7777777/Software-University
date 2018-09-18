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
            var employee = db.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                                    .Select(ep => new
                                    {
                                        ProjectName = ep.Project.Name
                                    })
                })
                .FirstOrDefault();

            var projects = employee.Projects
                .OrderBy(p => p.ProjectName)
                .ToList();

            Console.WriteLine($"{employee.Name} - {employee.JobTitle}");
            projects.ForEach(p => Console.WriteLine(p.ProjectName));
        }
    }
}