using P02_DatabaseFirst.Data;
using System;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var db = new SoftUniContext();

        using (db)
        {
            var projects = db.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Description);
                Console.WriteLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }
    }
}