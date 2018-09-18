using System;
using System.Collections.Generic;
using System.Text;
public class Human
{
    private const int MIN_FIRST_NAME_LENGTH = 4;
    private const int MIN_LAST_NAME_LENGTH = 3;

    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            ValidateFirstNameLenght(value, "firstName");
            ValidateUpperLetter(value, "firstName");
            firstName = value;
        }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            ValidateLastNameLenght(value, "lastName");
            ValidateUpperLetter(value, "lastName");
            lastName = value;
        }
    }
    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public void ValidateUpperLetter(string value, string valueName)
    {
        if (!char.IsUpper(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {valueName}");
        }
    }
    public void ValidateFirstNameLenght(string value, string valueName)
    {
        if (value.Length < MIN_FIRST_NAME_LENGTH)
        {
            throw new ArgumentException($"Expected length at least {MIN_FIRST_NAME_LENGTH} symbols! Argument: {valueName}");
        }
    }
    public void ValidateLastNameLenght(string value, string valueName)
    {
        if (value.Length < MIN_LAST_NAME_LENGTH)
        {
            throw new ArgumentException($"Expected length at least {MIN_LAST_NAME_LENGTH} symbols! Argument: {valueName}");
        }
    }
}

