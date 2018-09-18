using System;
using System.Collections.Generic;
using System.Text;
public static class Validator
{
    public static void ValidateMoney(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
    }

    public static void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }
}

