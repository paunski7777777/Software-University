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
            var project = db.Projects.Where(p => p.ProjectId == 2).FirstOrDefault();
            var employeeProjects = db.EmployeesProjects.Where(p => p.ProjectId == 2);

            db.EmployeesProjects.RemoveRange(employeeProjects);
            db.Projects.Remove(project);

            db.SaveChanges();

            var projects = db.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            projects.ForEach(p => Console.WriteLine(p));
        }
    }
}