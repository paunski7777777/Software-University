using System;
using System.Collections.Generic;
using System.Text;
public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        set
        {
            ValidateSides("Length", value);
            length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            ValidateSides("Width", value);
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            ValidateSides("Height", value);
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    public double CalculateSurfaceArea()
    {
        double result = 2 * length * width + 2 * length * height + 2 * width * height;

        return result;
    }
    public double CalculateLateralSurfaceArea()
    {
        double result = 2 * length * height + 2 * width * height;

        return result;
    }
    public double CalculateVolume()
    {
        double result = length * width * height;

        return result;
    }
    private void ValidateSides(string sideName, double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(sideName + " cannot be zero or negative.");
        }
    }
    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Surface Area - {CalculateSurfaceArea():f2}");
        result.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():f2}");
        result.AppendLine($"Volume - {CalculateVolume():f2}");

        return result.ToString().TrimEnd();
    }
}

