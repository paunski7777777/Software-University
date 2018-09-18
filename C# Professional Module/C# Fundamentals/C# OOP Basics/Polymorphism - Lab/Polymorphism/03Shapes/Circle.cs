using System;
using System.Collections.Generic;
using System.Text;
public class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    public Circle(double radius)
    {
        this.Radius = radius;
    }
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }
    public override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
    public sealed override string Draw()
    {
        return $"{base.Draw()} Circle";
    }
}

