using LoggerApp.Models.Contracts;
using LoggerApp.Models.Enums;

namespace LoggerApp.Models
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel level, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = level;
            this.logFile = logFile;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }
        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
        }
    }
}