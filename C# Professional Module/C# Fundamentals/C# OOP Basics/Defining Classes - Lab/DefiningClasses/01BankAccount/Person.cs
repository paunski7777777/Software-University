using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<BankAccount> accounts { get; set; }

    public Person()
    {
        this.accounts = new List<BankAccount>();
    }
    public Person(string name, int age) : this()
    {
        this.Name = name;
        this.Age = age;
    }
    public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
    {
        this.accounts.AddRange(accounts);
    }

    public decimal GetBalance()
    {
        return this.accounts.Sum(p => p.Balance);
    }
}

