using System;
using System.Collections.Generic;
using System.Text;
public class Animal : ISoundProducable
{
    private const string ERROR_MESSAGE = "Invalid input!";

    private string name;
    private string gender;
    private int age;
    public string Name
    {
        get { return name; }
        set
        {
            ValidateData(value);
            name = value;
        }
    }
    public string Gender
    {
        get { return gender; }
        set
        {
            ValidateData(value);
            gender = value;
        }
    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            age = value;
        }
    }
    public Animal(string name, string gender, int age)
    {
        this.Name = name;
        this.Gender = gender;
        this.Age = age;
    }
    private static void ValidateData(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(ERROR_MESSAGE);
        }
    }
    public virtual string ProduceSound()
    {
        return "NOISE!";
    }
    public override string ToString()
    {
        var result = new StringBuilder();
        result
            .AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine($"{this.ProduceSound()}");

        return result.ToString().TrimEnd();
    }
}

