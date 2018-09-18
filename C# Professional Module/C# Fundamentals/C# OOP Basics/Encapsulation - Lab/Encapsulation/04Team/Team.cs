using System;
using System.Collections.Generic;
using System.Text;
public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get => this.firstTeam.AsReadOnly();
    }
    public IReadOnlyCollection<Person> ReserveTeam
    {
        get => this.reserveTeam.AsReadOnly();
    }
    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }
    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"First team has {this.firstTeam.Count} players.");
        result.AppendLine($"Second team has {this.reserveTeam.Count} players.");

        return result.ToString().TrimEnd();
    }
}

