using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IList<string> arguments, IManager manager) 
        : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Quit(this.Arguments);
    }
}