using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        int villainId = int.Parse(Console.ReadLine());

        using (connection)
        {
            var villainNameSQL = $"SELECT [Name] FROM Villains WHERE Id = {villainId}";
            var commandVillain = new SqlCommand(villainNameSQL, connection);
            SqlDataReader readerVillain = commandVillain.ExecuteReader();

            var villianName = readerVillain.Read() ? $"Villain: {(string)readerVillain["Name"]}" : null;

            if (villianName is null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                Console.WriteLine(villianName);
            }

            readerVillain.Close();

            var minionsSQL = "SELECT m.[Name], m.Age " +
                            "FROM Minions AS m " +
                            "JOIN MinionsVillains AS mv " +
                            "ON mv.MinionId = m.Id " +
                            "JOIN Villains AS v " +
                            "ON v.Id = mv.VillainId " +
                            $"WHERE v.Id = {villainId} ";

            var minions = new List<Minion>();

            var commandMinion = new SqlCommand(minionsSQL, connection);
            SqlDataReader readerMinion = commandMinion.ExecuteReader();

            while (readerMinion.Read())
            {
                string minionName = (string)readerMinion["Name"];
                int minionAge = (int)readerMinion["Age"];
                Minion minion = new Minion(minionName, minionAge);
                minions.Add(minion);
            }

            if (villianName != null)
            {
                int count = 1;
                if (minions.Count == 0)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    foreach (var m in minions.OrderBy(m => m.Name))
                    {
                        Console.WriteLine($"{count++}. {m.Name} {m.Age}");
                    }
                }
            }
        }
    }
}