using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class CarManager
{
    private const string RaceProblem = "Cannot start the race with zero participants.";

    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> closedRaces;
    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.closedRaces = new List<int>();
    }
    public void Register(int id, string type, string brand, string model, int yearOfProduction,
        int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = null;

        if (type == "Performance")
        {
            car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.cars.Add(id, car);
        }
        else if (type == "Show")
        {
            car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.cars.Add(id, car);
        }
    }
    public string Check(int id)
    {
        return this.cars[id].ToString();
    }
    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = null;

        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool);
                this.races.Add(id, race);
                break;

            case "Drag":
                race = new DragRace(length, route, prizePool);
                this.races.Add(id, race);
                break;

            case "Drift":
                race = new DriftRace(length, route, prizePool);
                this.races.Add(id, race);
                break;
        }
    }
    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(carId))
        {
            if (!this.closedRaces.Contains(raceId))
            {
                this.races[raceId].Participants.Add(carId, cars[carId]);
            }
        }
    }
    public string Start(int id)
    {
        if (this.races[id].Participants.Count == 0)
        {
            return RaceProblem;
        }

        var result = this.races[id].StartRace();

        this.closedRaces.Add(id);

        return result;
    }
    public void Park(int id)
    {
        foreach (var race in this.races.Where(r => !closedRaces.Contains(r.Key)))
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return;
            }
        }

        this.garage.ParkCar(id);
    }
    public void Unpark(int id)
    {
        this.garage.UnparkCar(id);
    }
    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var parkedCar in this.garage.ParkedCars)
        {
            cars[parkedCar].TuneCar(tuneIndex, addOn);
        }
    }
}

