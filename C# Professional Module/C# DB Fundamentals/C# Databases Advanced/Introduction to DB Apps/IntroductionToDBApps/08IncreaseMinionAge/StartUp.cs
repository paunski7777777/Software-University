using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var minionIds = Console.ReadLine().Split().Select(int.Parse).ToList();

        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        var minions = new List<Minion>();

        using (connection)
        {
            string query = @"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + LOWER(RIGHT(Name, LEN(Name)-1)), Age += 1 WHERE Id IN(@idCollection)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(@"idCollection", string.Join(", ", minionIds));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];

                        var minion = new Minion(name, age);
                        minions.Add(minion);
                    }
                }
            }
        }

        foreach (var m in minions)
        {
            Console.WriteLine($"{m.Name} {m.Age}");
        }
    }
}