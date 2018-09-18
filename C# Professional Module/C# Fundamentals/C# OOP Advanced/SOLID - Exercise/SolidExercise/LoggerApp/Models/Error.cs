using LoggerApp.Models.Contracts;
using LoggerApp.Models.Enums;
using System;

namespace LoggerApp.Models
{
    public class Error : IError
    {
        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }

        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }
    }
}
