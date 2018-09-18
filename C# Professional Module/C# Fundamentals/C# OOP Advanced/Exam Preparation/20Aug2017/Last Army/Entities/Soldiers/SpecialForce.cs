using System.Collections.Generic;
public class SpecialForce : Soldier
{
    private const double overallSkillMultiplier = 3.5;
    private const int regenerateIncrease = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance) { }

    protected override double OverallSkillMultiplier => overallSkillMultiplier;
    protected override List<string> WeaponsAllowed => this.weaponsAllowed;
    protected override int RegenerateIncrease => regenerateIncrease;
}