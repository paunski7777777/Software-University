using LoggerApp.Models;
using LoggerApp.Models.Contracts;
using LoggerApp.Models.Factories;
using System;
using System.Collections.Generic;

namespace LoggerApp
{
    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        public static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string appenderType = input[0];
                string layoutType = input[1];
                string errorLevel = "INFO";

                if (input.Length == 3)
                {
                    errorLevel = input[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
