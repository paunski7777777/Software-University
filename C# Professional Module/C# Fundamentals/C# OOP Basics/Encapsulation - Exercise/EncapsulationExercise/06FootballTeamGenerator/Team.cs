using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Team
{
    private string name;
    public List<Player> Players { get; set; }
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    public int Rating => CalculateTeamRating();
    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }
    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }
    public void RemovePlayer(string playerName)
    {
        if (!this.Players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        else
        {
            var player = this.Players.FirstOrDefault(p => p.Name == playerName);
            this.Players.Remove(player);
        }
    }
    private int CalculateTeamRating()
    {
        if (this.Players.Any())
        {
            return (int)Math.Round(this.Players.Average(p => p.Stats));
        }
        else
        {
            return 0;
        }
    }
    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}

