using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class RaceTower
{
    private const string CrashReason = "Crashed";

    private Track track;
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;
    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
    }
    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];

            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();

            Tyre tyre = tyreFactory.CreateTyre(tyreArgs);

            Car car = new Car(hp, fuelAmount, tyre);

            Driver driver = driverFactory.CreateDriver(driverType, driverName, car);

            this.racingDrivers.Add(driver);
        }
        catch { }
    }
    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = this.racingDrivers.FirstOrDefault(d => d.Name == driverName);

        string[] methodArgs = commandArgs.Skip(2).ToArray();

        if (reasonToBox == "Refuel")
        {
            driver.RefuelCar(methodArgs);
        }
        else if (reasonToBox == "ChangeTyres")
        {
            Tyre tyre = tyreFactory.CreateTyre(methodArgs);
            driver.ChangeTyres(tyre);
        }
    }
    public string CompleteLaps(List<string> commandArgs)
    {
        var result = new StringBuilder();

        int completeLaps = int.Parse(commandArgs[0]);

        if (completeLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.track.CurrentLap));
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }

        for (int lapCounter = 0; lapCounter < completeLaps; lapCounter++)
        {
            for (int index = 0; index < this.racingDrivers.Count; index++)
            {
                Driver driver = racingDrivers[index];

                try
                {
                    driver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException ae)
                {
                    driver.Fail(ae.Message);
                    this.failedDrivers.Push(driver);
                    this.racingDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.track.CurrentLap++;

            var orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                Driver overtakingDriver = orderedDrivers[i];
                Driver targetDriver = orderedDrivers[i + 1];

                bool overtakeHappened = TryOverTake(overtakingDriver, targetDriver);

                if (overtakeHappened)
                {
                    i++;
                    result
                        .AppendLine(string
                        .Format(OutputMessages.OvertakeMessage, overtakingDriver.Name, targetDriver.Name, this.track.CurrentLap));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (this.IsRaceOver)
        {
            Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();

            result.AppendLine(string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
        }

        return result.ToString().TrimEnd();
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDifference = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre;
        bool enduranceDriver = overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.track.Weather == Weather.Foggy)
            || (enduranceDriver && this.track.Weather == Weather.Rainy);

        if ((aggressiveDriver || enduranceDriver) && timeDifference <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(CrashReason);

                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;

            return true;
        }

        else if (timeDifference <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;

            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder();

        result.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderboardDrivers = this.racingDrivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int position = 1;
        foreach (var driver in leaderboardDrivers)
        {
            result.AppendLine($"{position++} {driver.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];

        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);

        if (validWeather)
        {
            Weather weather = (Weather)weatherObj;
            this.track.Weather = weather;
        }
    }
}

