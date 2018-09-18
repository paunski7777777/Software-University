using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string connectionString = @"Server=ALEX\SQLEXPRESS;"
                                + @"Database=SoftUni;"
                                + @"Integrated Security=True";

        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        
        using (connection)
        {
            string commandText = "SELECT FirstName, LastName, JobTitle FROM Employees";
            SqlCommand command = new SqlCommand(commandText, connection);

            SqlDataReader reader = command.ExecuteReader();

            var people = new List<Person>();

            while (reader.Read())
            {
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string jobTitle = (string)reader["JobTitle"];

                Person person = new Person(firstName, lastName, jobTitle);
                people.Add(person);
            }

            var groupedPeople = people
                .GroupBy(p => p.JobTitle)
                .OrderByDescending(g => g.Count())
                .ToList();

            foreach (var group in groupedPeople)
            {
                Console.WriteLine($"{group.Key}: ({group.Count()} people): ");
                foreach (var person in group)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
