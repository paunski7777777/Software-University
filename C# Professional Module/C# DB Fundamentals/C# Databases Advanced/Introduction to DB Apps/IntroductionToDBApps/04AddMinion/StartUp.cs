using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var minionInfo = Console.ReadLine().Split(" :".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string minionName = minionInfo[1];
        int minionAge = int.Parse(minionInfo[2]);
        string minionTown = minionInfo[3];

        var villainInfo = Console.ReadLine().Split(" :".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string villainName = villainInfo[1];

        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        using (connection)
        {
            string townNameSQL = $"SELECT Name FROM Towns WHERE Name = '{minionTown}'";
            var command = new SqlCommand(townNameSQL, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();

                string insertTownSQL = $"INSERT INTO Towns (Name) VALUES ('{minionTown}')";
                command = new SqlCommand(insertTownSQL, connection);
                command.ExecuteNonQuery();

                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            reader.Close();

            string villainSQL = $"SELECT Name FROM Villains WHERE Name = '{villainName}'";
            command = new SqlCommand(villainSQL, connection);
            reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();

                string insertVillainSQL = $"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villainName}', 4)";
                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            reader.Close();

            string minionIdSQL = $"SELECT Id FROM Minions WHERE Name = '{minionName}'";
            command = new SqlCommand(minionIdSQL, connection);
            reader = command.ExecuteReader();
            int minionId = 0;

            while (reader.Read())
            {
                minionId = (int)reader["Id"];
            }
            reader.Close();

            string villainIdSQL = $"SELECT Id FROM Villains WHERE Name = '{villainName}'";
            command = new SqlCommand(minionIdSQL, connection);
            reader = command.ExecuteReader();
            int villainId = 0;

            while (reader.Read())
            {
                villainId = (int)reader["Id"];
            }
            reader.Close();

            string insertMinionToVillainSQL = $"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES ({minionId}, {villainId})";
            command = new SqlCommand(insertMinionToVillainSQL, connection);
            command.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}