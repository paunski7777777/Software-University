using P02_DatabaseFirst.Data;
using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string town = Console.ReadLine();

        var db = new SoftUniContext();

        using (db)
        {
            var townToDelete = db.Towns
                .Where(t => t.Name == town)
                .FirstOrDefault();

            var addresses = db.Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToList();

            foreach (var a in addresses)
            {
                var employeeAddresses = db.Employees
                    .Where(e => e.AddressId == a.AddressId)
                    .ToList();

                foreach (var ea in employeeAddresses)
                {
                    ea.AddressId = null;
                }
            }

            db.Addresses.RemoveRange(addresses);
            db.Towns.Remove(townToDelete);
            db.SaveChanges();

            var removedAddresses = addresses.Count;
            var addressesSingleOrPlural = removedAddresses > 1 ? "addresses" : "address";
            var wasOrWere = removedAddresses > 1 ? "were" : "was";

            Console.WriteLine($"{removedAddresses} {addressesSingleOrPlural} in {town} {wasOrWere} deleted");
        }
    }
}