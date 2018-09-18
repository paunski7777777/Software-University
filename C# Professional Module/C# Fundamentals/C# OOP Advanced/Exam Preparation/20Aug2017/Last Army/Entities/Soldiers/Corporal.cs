using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double overallSkillMultiplier = 2.5;

    

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(Helmet),
            nameof(Knife),
        };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance) { }

    protected override double OverallSkillMultiplier => overallSkillMultiplier;
    protected override List<string> WeaponsAllowed => this.weaponsAllowed;
}
