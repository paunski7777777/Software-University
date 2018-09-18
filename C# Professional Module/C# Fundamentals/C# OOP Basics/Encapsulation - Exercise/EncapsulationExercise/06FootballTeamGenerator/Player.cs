using System;
using System.Collections.Generic;
using System.Text;
public class Player
{
    private const int MIN_STAT = 0;
    private const int MAX_STAT = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
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
    public int Shooting
    {
        get { return shooting; }
        set
        {
            ValidateStats(value, "Shooting");
            shooting = value;
        }
    }
    public int Passing
    {
        get { return passing; }
        set
        {
            ValidateStats(value, "Passing");
            passing = value;
        }
    }
    public int Dribble
    {
        get { return dribble; }
        set
        {
            ValidateStats(value, "Dribble");
            dribble = value;
        }
    }
    public int Sprint
    {
        get { return sprint; }
        set
        {
            ValidateStats(value, "Sprint");
            sprint = value;
        }
    }
    public int Endurance
    {
        get { return endurance; }
        set
        {
            ValidateStats(value, "Endurance");
            endurance = value;
        }
    }
    public int Stats => CalculateOverallStats();
    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }
    private int CalculateOverallStats()
    {
        return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
    }
    private void ValidateStats(int value, string valueName)
    {
        if (value < MIN_STAT || value > MAX_STAT)
        {
            throw new ArgumentException($"{valueName} should be between {MIN_STAT} and {MAX_STAT}.");
        }
    }
}

