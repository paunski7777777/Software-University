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
            var addresses = db.Addresses
                .Select(a => new
                {
                    EmployeeCount = a.Employees.Count,
                    TownName = a.Town.Name,
                    AddressText = a.AddressText
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            addresses.ForEach(a => Console.WriteLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees"));
        }
    }
}