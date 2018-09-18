public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        Car car = this.Participants[id];

        return car.HorsePower / car.Acceleration;
    }
}

