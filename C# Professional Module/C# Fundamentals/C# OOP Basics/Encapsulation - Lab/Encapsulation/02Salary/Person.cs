using System;
using System.Collections.Generic;
using System.Text;
public class Person
{
    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private string lastName;
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    private int age;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age <= 30)
        {
            this.Salary += this.Salary * percentage / 200;
        }
        else
        {
            this.Salary += this.Salary * percentage / 100;
        }
    }
    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}

