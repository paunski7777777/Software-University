using LoggerApp.Models.Contracts;
using System.Globalization;

namespace LoggerApp.Models
{
    public class SimpleLayout : ILayout
    {
        const string Format = "{0} - {1} - {2}";
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formatedError;
        }
    }
}
