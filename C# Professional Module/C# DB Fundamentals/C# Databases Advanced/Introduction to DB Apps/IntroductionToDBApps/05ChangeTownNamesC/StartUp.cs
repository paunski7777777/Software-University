using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        string country = Console.ReadLine();

        using (connection)
        {          
            int countryId = GetCountryId(country, connection);

            if (countryId == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                int rowsAffected = UpdateNames(countryId, connection);
                List<string> names = GetNames(countryId, connection);

                Console.WriteLine($"{rowsAffected} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", names)}]");
            }

            connection.Close();
        }
    }

    private static List<string> GetNames(int countryId, SqlConnection connection)
    {
        var names = new List<string>();

        var namesSQL = @"SELECT Name FROM Towns WHERE CountryCode = @countryId";

        using (SqlCommand command = new SqlCommand(namesSQL, connection))
        {
            command.Parameters.AddWithValue("@countryId", countryId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add((string)reader["Name"]);
                }
            }
        }

        return names;
    }

    private static int UpdateNames(int countryId, SqlConnection connection)
    {
        string updateNamesSQL = @"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @countryId";

        using (SqlCommand command = new SqlCommand(updateNamesSQL, connection))
        {
            command.Parameters.AddWithValue("@countryId", countryId);

            return command.ExecuteNonQuery();
        }
    }

    private static int GetCountryId(string country, SqlConnection connection)
    {
        string countryIdSQL = @"SELECT TOP(1) c.Id FROM Towns AS t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.[Name] = @name";

        using (SqlCommand command = new SqlCommand(countryIdSQL, connection))
        {
            command.Parameters.AddWithValue("@name", country);

            if (command.ExecuteScalar() == null)
            {
                return 0;
            }

            return (int)command.ExecuteScalar();
        }
    }
}