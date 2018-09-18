using System;
using System.Collections.Generic;
using System.Text;
public class Rectangle : Shape
{
    private double height;
    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }
    public override double CalculatePerimeter()
    {
        return this.Height * 2 + this.Width * 2;
    }
    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }
    public sealed override string Draw()
    {
        return $"{base.Draw()} Rectangle";
    }
}

