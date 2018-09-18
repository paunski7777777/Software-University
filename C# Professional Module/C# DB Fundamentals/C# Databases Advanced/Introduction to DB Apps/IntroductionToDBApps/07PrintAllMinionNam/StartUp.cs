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
            string commandText = "SELECT Name FROM Minions";
            var command = new SqlCommand(commandText, connection);
            var reader = command.ExecuteReader();
            var names = new List<string>();

            using (reader)
            {
                try
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["Name"]);
                        names.Add(name);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - 1 - i]);
            }

            if (names.Count % 2 != 0)
            {
                Console.WriteLine(names[names.Count / 2]);
            }
        }
    }
}
