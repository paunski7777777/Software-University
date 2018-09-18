using System;
public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override bool Equals(object obj)
    {
        return this.Name == ((Person)obj).Name && this.Age == ((Person)obj).Age;
    }
    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }
    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }
}

