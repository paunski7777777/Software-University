namespace P01_BillsPaymentSystem
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BillsPaymentSystemContext();

            //using (db)
            //{
            //    db.Database.EnsureDeleted();
            //    //db.Database.EnsureCreated();
            //    db.Database.Migrate();

            //    Seed(db);
            //}

            var userId = int.Parse(Console.ReadLine());

            using (db)
            {
                GetUserInfo(userId, db);
            }
        }
        private static void PayBills(User user, decimal amount)
        {
            var bankAccountTotals = user.PaymentMethods
                .Where(ba => ba.BankAccount != null)
                .Sum(b => b.BankAccount.Balance);

            var creditCardTotals = user.PaymentMethods
                .Where(cc => cc.CreditCard != null)
                .Sum(ll => ll.CreditCard.LimitLeft);

            var totalAmount = bankAccountTotals + creditCardTotals;

            if (totalAmount >= amount)
            {
                var bankAccounts = user.PaymentMethods
                    .Where(ba => ba.BankAccount != null)
                    .Select(ba => ba.BankAccount)
                    .OrderBy(bai => bai.BankAccountId)
                    .ToList();

                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        bankAccount.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= bankAccount.Balance;
                        bankAccount.Withdraw(bankAccount.Balance);
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }

                var creditCards = user.PaymentMethods
                    .Where(cc => cc.CreditCard != null)
                    .Select(cc => cc.CreditCard)
                    .OrderBy(ci => ci.CreditCardIt)
                    .ToList();

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        private static void GetUserInfo(int userId, BillsPaymentSystemContext db)
        {
            var user = db.Users
                                .Where(ui => ui.UserId == userId)
                                .Select(u => new
                                {
                                    Name = $"{u.FirstName} {u.LastName}",
                                    CreditCards = u.PaymentMethods
                                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                                        .Select(pm => pm.CreditCard),
                                    BankAccounts = u.PaymentMethods
                                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                                        .Select(pm => pm.BankAccount)
                                })
                                .FirstOrDefault(); ;

            Console.WriteLine($"User: {user.Name}");

            var bankaccounts = user.BankAccounts.ToList();
            if (bankaccounts.Any())
            {
                Console.WriteLine("Bank Accounts:");
                foreach (var ba in bankaccounts)
                {
                    Console.WriteLine($"-- ID: {ba.BankAccountId}");
                    Console.WriteLine($"--- Balance: {ba.Balance:f2}");
                    Console.WriteLine($"--- Bank: {ba.BankName}");
                    Console.WriteLine($"--- SWIFT: {ba.SwiftCode}");
                }
            }

            var creditCards = user.CreditCards.ToList();
            if (creditCards.Any())
            {
                Console.WriteLine("Credit Cards:");
                foreach (var cc in creditCards)
                {
                    Console.WriteLine($"-- ID: {cc.CreditCardIt}");
                    Console.WriteLine($"--- Limit: {cc.Limit:f2}");
                    Console.WriteLine($"--- Money Owed: {cc.MoneyOwed:f2}");
                    Console.WriteLine($"--- Limit Left: {cc.LimitLeft:f2}");
                    Console.WriteLine($"--- Expiration Date: {cc.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                }
            }
        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            using (db)
            {
                var user = new User()
                {
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    Email = "pesho@abv.bg",
                    Password = "azsumpesho"
                };

                var creditCards = new CreditCard[]
                {
                new CreditCard()
                {
                    ExpirationDate = DateTime.ParseExact("20.05.2020", "dd.MM.yyyy", null),
                    Limit = 1000m,
                    MoneyOwed = 5m
                },
                new CreditCard()
                {
                    ExpirationDate = DateTime.ParseExact("21.05.2020", "dd.MM.yyyy", null),
                    Limit = 400m,
                    MoneyOwed = 200m
                }
                };

                var bankAccount = new BankAccount()
                {
                    Balance = 1500m,
                    BankName = "Swiss Bank",
                    SwiftCode = "SWSSBANK"
                };

                var paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[0],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[1],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        BankAccount = bankAccount,
                        Type = PaymentMethodType.BankAccount
                    }
                };

                db.Users.Add(user);
                db.CreditCards.AddRange(creditCards);
                db.BankAccounts.Add(bankAccount);
                db.PaymentMethods.AddRange(paymentMethods);

                db.SaveChanges();
            }
        }
    }
}