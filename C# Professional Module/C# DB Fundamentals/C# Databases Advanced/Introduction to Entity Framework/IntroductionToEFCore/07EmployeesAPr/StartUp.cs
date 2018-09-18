using P02_DatabaseFirst.Data;
using System;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var dbContext = new SoftUniContext();

        using (dbContext)
        {
            var employees = dbContext.Employees
                .Where(e => e.EmployeesProjects
                                .Any(p => p.Project.StartDate.Year >= 2001
                                && p.Project.StartDate.Year <= 2003))
                 .Take(30)
                 .Select(e => new
                 {
                     Name = $"{e.FirstName} {e.LastName}",
                     Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                     Projects = e.EmployeesProjects.Select(ep => new
                     {
                         ep.Project.Name,
                         ep.Project.StartDate,
                         ep.Project.EndDate
                     })
                 })
                 .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name} - Manager: {e.Manager}");

                foreach (var p in e.Projects)
                {
                    var endDate = string.Empty;

                    if (p.EndDate == null)
                    {
                        endDate = "not finished";
                    }
                    else
                    {
                        endDate = p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }

                    Console.WriteLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }
        }
    }
}