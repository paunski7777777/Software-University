using System;
using System.Collections.Generic;
using System.Text;
public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public string Intersection(Rectangle rectangle)
    {
        if ((rectangle.Y >= this.Y && rectangle.Y - rectangle.Height <= this.Y && rectangle.X <= this.X && rectangle.X + rectangle.Width >= this.X) ||
           (rectangle.Y >= this.Y && rectangle.Y - rectangle.Height <= this.Y && rectangle.X >= this.X && rectangle.X <= this.X + this.Width) ||
           (rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.Height && rectangle.X <= this.X && rectangle.X + rectangle.Width >= this.X) ||
           (rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.Height && rectangle.X >= this.X && rectangle.X <= this.X + this.Width))
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }
}
