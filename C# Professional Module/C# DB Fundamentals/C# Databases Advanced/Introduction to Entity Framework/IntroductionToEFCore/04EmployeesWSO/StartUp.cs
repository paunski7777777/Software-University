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
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName)
                .ToList();

            employees.ForEach(e => Console.WriteLine(e));
        }
    }
}