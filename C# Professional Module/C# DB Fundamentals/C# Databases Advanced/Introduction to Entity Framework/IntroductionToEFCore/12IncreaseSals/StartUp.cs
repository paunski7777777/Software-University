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
            var employees = db.Employees
                .Where(e => e.DepartmentId == 1 || e.DepartmentId == 2 || e.DepartmentId == 4 || e.DepartmentId == 11)
                .ToList();

            employees.ForEach(e => e.Salary *= (decimal)1.12);

            db.SaveChanges();

            var ordered = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            ordered.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
        }
    }
}
