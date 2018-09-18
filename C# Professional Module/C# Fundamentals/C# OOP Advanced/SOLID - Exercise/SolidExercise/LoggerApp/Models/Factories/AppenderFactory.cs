using LoggerApp.Models.Contracts;
using LoggerApp.Models.Enums;
using System;

namespace LoggerApp.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;
        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }
        public IAppender CreateAppender(string type, string errorLevel, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel level = this.ParseErrorLevel(errorLevel);

            IAppender appender = null;

            switch (type)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, level);
                    break;

                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, level, logFile);
                    break;

                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), errorLevel);

                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel type!", ae);
            }
        }
    }
}
