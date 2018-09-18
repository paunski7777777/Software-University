using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private const string RaceProblem = "Cannot start the race with zero participants.";
    public int Length { get; set; }
    public string Route { get; set; }
    public int PrizePool { get; set; }
    public Dictionary<int, Car> Participants { get; set; }
    public List<Car> Winners { get; set; }
    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
        this.Winners = new List<Car>();
    }
    public abstract int GetPerformance(int id);
    public Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants
            .OrderByDescending(w => this.GetPerformance(w.Key))
            .Take(3)
            .ToDictionary(w => w.Key, wi => wi.Value);

        return winners;
    }
    public List<int> GetPrizes()
    {
        var prizes = new List<int>
        {
            (this.PrizePool * 50) / 100,
            (this.PrizePool * 30) / 100,
            (this.PrizePool * 20) / 100
        };

        return prizes;
    }
    public string StartRace()
    {
        var winners = GetWinners();
        var prizes = GetPrizes();

        if (this.Participants.Count == 0)
        {
            return RaceProblem;
        }

        var result = new StringBuilder()
            .AppendLine($"{this.Route} - {this.Length}");

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);

            result.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }

        return result.ToString().TrimEnd();
    }
}

