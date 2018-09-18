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
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
        }
    }
}