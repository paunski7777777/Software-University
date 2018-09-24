using System;
public class BankAccount
{
    public decimal Balance { get; set; }
    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        if (this.Balance < amount)
        {
            throw new ArgumentException("Insufficient funds");
        }

        this.Balance -= amount;
    }
}