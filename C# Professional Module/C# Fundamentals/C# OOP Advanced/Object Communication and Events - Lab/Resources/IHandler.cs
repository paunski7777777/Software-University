using Object_Communication_and_Events_Lab;

public interface IHandler
    {
        void Handle(LogType logType, string message);
        void SetSuccessor(IHandler successor);
    }