using NUnit.Framework;
using System;
public class Test
{
    [Test]
    public void DepositShouldIncreaseBalance()
    {
        BankAccount bankAccount = new BankAccount();
        bankAccount.Deposit(50m);
        Assert.That(bankAccount.Balance, Is.EqualTo(50m));
        // Assert.AreEqual(2000, bankAccount.Balance);
    }

    [Test]
    public void WithdrawTest()
    {
        BankAccount bankAccount = new BankAccount();
        Assert.Throws<ArgumentException>(() => bankAccount.Withdraw(10000));
    }
}