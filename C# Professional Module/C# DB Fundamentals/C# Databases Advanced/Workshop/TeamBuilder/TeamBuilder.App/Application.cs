namespace TeamBuilder.App
{
    using TeamBuilder.App.Core;

    public class Application
    {
        public static void Main()
        {
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}