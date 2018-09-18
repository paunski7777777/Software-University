public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        Car car = this.Participants[id];

        return (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
    }
}

