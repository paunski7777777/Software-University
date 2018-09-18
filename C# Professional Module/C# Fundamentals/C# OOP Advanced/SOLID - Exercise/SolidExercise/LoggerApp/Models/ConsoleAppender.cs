using LoggerApp.Models.Contracts;
using LoggerApp.Models.Enums;
using System;

namespace LoggerApp.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }
        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formatedError = this.Layout.FormatError(error);

            Console.WriteLine(formatedError);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}";
        }
    }
}
