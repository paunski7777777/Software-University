using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IList<string> arguments, IManager manager)
        : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddHero(this.Arguments);
    }
}