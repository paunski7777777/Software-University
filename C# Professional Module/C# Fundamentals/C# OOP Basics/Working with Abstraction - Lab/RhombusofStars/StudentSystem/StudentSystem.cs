using System;
using System.Collections.Generic;

class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string input)
    {
        string[] args = input.Split();

        if (args[0] == "Create")
        {
            Create(args);
        }
        else if (args[0] == "Show")
        {
            Show(args);
        }
    }

    private void Show(string[] args)
    {
        var name = args[1];
        if (repo.ContainsKey(name))
        {
            var student = repo[name];
            string view = $"{student.Name} is {student.Age} years old.";
            view = GetGrade(student, view);

            Console.WriteLine(view);
        }

    }

    private static string GetGrade(Student student, string view)
    {
        if (student.Grade >= 5.00)
        {
            return "Excellent student.";
        }
        else if (student.Grade < 5.00 && student.Grade >= 3.50)
        {
            return "Average student.";
        }
        else
        {
            return "Very nice person.";
        }
    }

    private void Create(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}

