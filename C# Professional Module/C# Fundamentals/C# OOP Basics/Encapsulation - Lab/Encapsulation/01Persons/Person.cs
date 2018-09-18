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
    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }
    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    }
}

