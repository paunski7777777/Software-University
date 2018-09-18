using System;
using System.Collections.Generic;
using System.Linq;

public class CompanyRoster
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];

            var employee = new Employee(name, salary, position, department);

            if (input.Length > 4)
            {
                string emailOrAge = input[4];

                if (emailOrAge.Contains("@"))
                {
                    employee.Email = emailOrAge;
                }
                else
                {
                    employee.Age = int.Parse(emailOrAge);
                }
            }

            if (input.Length > 5)
            {
                employee.Age = int.Parse(input[5]);
            }

            employees.Add(employee);
        }

        var filtered = employees
            .GroupBy(e => e.Department)
            .Select(d => new
            {
                Department = d.Key,
                AverageSalary = d.Average(e => e.Salary),
                Employees = d.OrderByDescending(e => e.Salary).ToList()
            })
            .OrderByDescending(d => d.AverageSalary)
            .First();

        Console.WriteLine($"Highest Average Salary: {filtered.Department}");
        foreach (var employee in filtered.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}

