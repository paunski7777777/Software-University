using LoggerApp.Models.Contracts;
using System;
using System.Globalization;

namespace LoggerApp.Models
{
    public class XmlLayout : ILayout
    {
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";
        private string Format =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<messages>{2}</messages>" + Environment.NewLine +
            "</log>";
        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formatedError = string.Format(Format, dateString, error.Level, error.Message);

            return formatedError;
        }
    }
}
