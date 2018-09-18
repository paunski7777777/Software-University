public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        Car car = this.Participants[id];

        return car.Suspension + car.Durability;
    }
}

