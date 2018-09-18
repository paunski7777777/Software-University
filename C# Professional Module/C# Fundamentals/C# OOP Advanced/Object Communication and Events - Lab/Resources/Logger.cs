using Object_Communication_and_Events_Lab;

public abstract class Logger : IHandler
{
    private IHandler successor;

    public void SetSuccessor(IHandler successor)
    {
        this.successor = successor;
    }

    protected void PassToSuccessor(LogType logType, string message)
    {
        if (this.successor != null)
        {
            this.successor.Handle(logType, message);
        }
    }

    public abstract void Handle(LogType logType, string message);
}
