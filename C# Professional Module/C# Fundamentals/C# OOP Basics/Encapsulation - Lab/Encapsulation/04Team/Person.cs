using System;
using System.Collections.Generic;
using System.Text;
public class Person
{
    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            ValidateFieldData(value, "First name");
            firstName = value;
        }
    }

    private string lastName;
    public string LastName
    {
        get { return lastName; }
        set
        {
            ValidateFieldData(value, "Last name");
            lastName = value;
        }
    }
    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            salary = value;
        }
    }
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    private void ValidateFieldData(string fieldValue, string fieldName)
    {
        if (fieldValue?.Length < 3)
        {
            throw new ArgumentException(fieldName + " cannot contain fewer than 3 symbols!");
        }
        fieldValue = fieldName;
    }
}

