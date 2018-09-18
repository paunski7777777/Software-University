using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Smartphone : ICallable, IBrowsable
{
    public const string ERROR_NUMBER = "Invalid number!";
    public const string ERROR_URL = "Invalid URL!";
    public string Calling(string number)
    {
        if (!number.Any(ch => char.IsDigit(ch)))
        {
            return ERROR_NUMBER;
        }
        return $"Calling... {number}";
    }
    public string Browsing(string site)
    {
        if (site.Any(ch => char.IsDigit(ch)))
        {
            return ERROR_URL;
        }
        return $"Browsing: {site}!";
    }
    public Smartphone()
    {

    }
}

