using System;
using System.Collections.Generic;
using System.Text;
class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public Company()
    {

    }
    public Company(string name, string department, double salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }
}

