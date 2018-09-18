using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        using (connection)
        {
            var villainWithMinionsCount = "SELECT v.[Name], COUNT(mv.MinionId) AS [MinionsCount] " +
                                          "FROM Villains AS v " +
                                          "JOIN MinionsVillains AS mv " +
                                              "ON mv.VillainId = v.Id " +
                                          "JOIN Minions AS m " +
                                              "ON m.Id = mv.MinionId " +
                                          "GROUP BY v.[Name] " +
                                          "HAVING COUNT(mv.MinionId) > 3 " +
                                          "ORDER BY[MinionsCount] DESC ";

            var command = new SqlCommand(villainWithMinionsCount, connection);
            SqlDataReader reader = command.ExecuteReader();
            var villains = new List<Villain>();

            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];
                var villain = new Villain(villainName, minionsCount);
                villains.Add(villain);
            }

            foreach (var v in villains)
            {
                Console.WriteLine(v);
            }
        }
    }
}