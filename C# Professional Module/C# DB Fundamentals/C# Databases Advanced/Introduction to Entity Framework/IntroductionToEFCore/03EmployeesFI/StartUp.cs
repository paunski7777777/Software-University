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
            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();

            employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
        }
    }
}