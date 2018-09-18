using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }
    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}

