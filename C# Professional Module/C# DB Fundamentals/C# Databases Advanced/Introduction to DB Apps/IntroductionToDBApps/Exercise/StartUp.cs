using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main()
    {
        var connection = new SqlConnection(Configuration.ConnectionString);
        connection.Open();

        using (connection)
        {
            string createDatabaseSQL = "CREATE DATABASE MinionsDB";
            ExecuteCommand(createDatabaseSQL, connection);
        }

        connection = new SqlConnection(Configuration.CurrentConnectionString);
        connection.Open();

        using (connection)
        {
            string createCountriesSQL = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
            string createTownsSQL = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
            string createMinionsSQL = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
            string createEvilnessFactorsSQL = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
            string createVillainsSQL = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
            string createMinionsVillainsSQL = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

            ExecuteCommand(createCountriesSQL, connection);
            ExecuteCommand(createTownsSQL, connection);
            ExecuteCommand(createMinionsSQL, connection);
            ExecuteCommand(createEvilnessFactorsSQL, connection);
            ExecuteCommand(createVillainsSQL, connection);
            ExecuteCommand(createMinionsVillainsSQL, connection);

            string insertCountriesSQL = "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
            string insertTownsSQL = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
            string insertMinionsSQL = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
            string insertEvilnessFactorsSQL = "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
            string insertVillainsSQL = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
            string insertMinionsVillainsSQL = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

            ExecuteCommand(insertCountriesSQL, connection);
            ExecuteCommand(insertTownsSQL, connection);
            ExecuteCommand(insertMinionsSQL, connection);
            ExecuteCommand(insertEvilnessFactorsSQL, connection);
            ExecuteCommand(insertVillainsSQL, connection);
            ExecuteCommand(insertMinionsVillainsSQL, connection);
        }
    }

    public static void ExecuteCommand(string commandSQL, SqlConnection connection)
    {
        var command = new SqlCommand(commandSQL, connection);
        command.ExecuteNonQuery();
    }
}