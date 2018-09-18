using System;
using System.Data.SqlClient;
public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        int villainId = int.Parse(Console.ReadLine());

        using (connection)
        {
            try
            {
                string villainNameSQL = "SELECT Name FROM Villains WHERE Id = @villainId";
                var villainNameCommand = new SqlCommand(villainNameSQL, connection);
                villainNameCommand.Parameters.AddWithValue("@villainId", villainId);
                SqlDataReader reader = villainNameCommand.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();
                    throw new ArgumentException("No such villain was found.");
                }

                string villainName = (string)reader["Name"];
                reader.Close();

                string deleteMVsql = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                var deleteMVcommand = new SqlCommand(deleteMVsql, connection);
                deleteMVcommand.Parameters.AddWithValue("@villainId", villainId);

                int releasedMinions = deleteMVcommand.ExecuteNonQuery();

                string villainSQL = "DELETE FROM Villains WHERE Id = @villainId";
                var deleteVillainCommand = new SqlCommand(villainSQL, connection);
                deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
                deleteVillainCommand.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
