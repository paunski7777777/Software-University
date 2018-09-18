using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();

        string input;
        while (!(input = Console.ReadLine()).Equals("End"))
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            switch (command)
            {
                case "Create":
                    Create(tokens, accounts);
                    break;

                case "Deposit":
                    Deposit(tokens, accounts);
                    break;
                case "Withdraw":
                    Withdraw(tokens, accounts);
                    break;

                case "Print":
                    Print(tokens, accounts);
                    break;

                default:
                    break;
            }
        }
    }

    private static void Print(string[] tokens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine(accounts[id]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] tokens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);
        int amount = int.Parse(tokens[2]);

        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance >= amount)
            {
                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] tokens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);
        int amount = int.Parse(tokens[2]);

        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] tokens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tokens[1]);

        if (!accounts.ContainsKey(id))
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Id = id;
            accounts.Add(id, bankAccount);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}

