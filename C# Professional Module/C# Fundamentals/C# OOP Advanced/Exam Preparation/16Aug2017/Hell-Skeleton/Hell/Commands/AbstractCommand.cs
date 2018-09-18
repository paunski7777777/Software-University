using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    public IList<string> Arguments { get; private set; }
    public IManager Manager { get; private set; }
    protected AbstractCommand(IList<string> arguments, IManager manager)
    {
        this.Arguments = arguments;
        this.Manager = manager;
    }
    public abstract string Execute();
}