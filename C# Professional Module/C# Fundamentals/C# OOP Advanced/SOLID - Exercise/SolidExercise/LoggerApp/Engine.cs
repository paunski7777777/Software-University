using LoggerApp.Models.Contracts;
using LoggerApp.Models.Factories;
using System;

namespace LoggerApp
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;
        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('|');
                string errorLevel = tokens[0];
                string dateTime = tokens[1];
                string message = tokens[2];

                IError error = errorFactory.CreateError(dateTime, errorLevel, message);

                logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
