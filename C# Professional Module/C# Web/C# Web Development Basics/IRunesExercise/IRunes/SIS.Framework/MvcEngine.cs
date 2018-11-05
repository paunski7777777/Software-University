namespace SIS.Framework
{
    using SIS.WebServer;

    using System;
    using System.Reflection;

    public class MvcEngine
    {
        public void Run(Server server)
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}