using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const string FACULTY_NUMBER_PATTERN = @"^[A-Za-z0-9]{5,10}$";

    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (!Regex.IsMatch(value, FACULTY_NUMBER_PATTERN))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }
    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }
    public override string ToString()
    {
        var studentInfo = new StringBuilder();

        studentInfo.AppendLine($"First Name: {this.FirstName}");
        studentInfo.AppendLine($"Last Name: {this.LastName}");
        studentInfo.AppendLine($"Faculty number: {this.FacultyNumber}");

        return studentInfo.ToString().TrimEnd();
    }
}

