using LoggerApp.Models.Contracts;
using LoggerApp.Models.Enums;
using System;
using System.Globalization;

namespace LoggerApp.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

            IError error = new Error(dateTime, errorLevel, message);

            return error;
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
