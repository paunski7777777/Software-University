namespace IRunes.App
{
    using Services;
    using Services.Contracts;

    using SIS.Framework;
    using SIS.Framework.Routers;

    using SIS.WebServer;

    using System;
    using System.Collections.Generic;

    public class IRunesStartUp
    {
        public static void Main()
        {
            var dependencyMap = new Dictionary<Type, Type>();
            var dependencyContainer = new DependencyContainer(dependencyMap);
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();
            var handlingContext = new HttpRouteHandlingContext(new ControllerRouter(dependencyContainer), new ResourceRouter());
            Server server = new Server(80, handlingContext);
            var engine = new MvcEngine();
            engine.Run(server);
        }
    }
}