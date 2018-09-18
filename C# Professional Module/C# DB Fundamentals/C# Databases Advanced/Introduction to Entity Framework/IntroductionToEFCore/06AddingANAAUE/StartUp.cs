using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var dbContext = new SoftUniContext();

        using (dbContext)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = dbContext.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;

            dbContext.SaveChanges();

            var employees = dbContext.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            employees.ForEach(e => Console.WriteLine(e));
        }

    }
}