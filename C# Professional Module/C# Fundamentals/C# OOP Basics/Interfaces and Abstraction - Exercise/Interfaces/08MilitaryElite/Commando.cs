using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Commando : SpecialisedSoldier, ICommando
{
    private ICollection<IMission> missions;
    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;
    public Commando(int id, string firstName, string lastName, decimal salary, string corps)
        :base(id, firstName, lastName, salary, corps)
    {
        missions = new List<IMission>();
    }
    public void AddMission(IMission mission)
    {
        missions.Add(mission);
    }

    public void CompleteMission(string missionCodeName)
    {
        IMission mission = this.Missions.FirstOrDefault(m => m.CodeName == missionCodeName);

        if (mission == null)
        {
            throw new ArgumentException("Mission not found!");
        }

        mission.Complete();
    }
    public override string ToString()
    {
        var commandoInfo = new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps.ToString()}")
            .AppendLine("Missions:");

        foreach (var mission in missions)
        {
            commandoInfo.AppendLine($"  {mission.ToString()}");
        }

        string result = commandoInfo.ToString().TrimEnd();
        return result;
    }
}

