namespace Chushka
{
    using SIS.MvcFramework;

    public class Launcher
    {
        public static void Main() => WebHost.Start(new StartUp());
    }
}