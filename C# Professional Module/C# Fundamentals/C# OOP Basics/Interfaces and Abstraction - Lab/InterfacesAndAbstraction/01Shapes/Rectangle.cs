using System;
using System.Collections.Generic;
using System.Text;
public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public int Height
    {
        get { return height; }
        protected set { height = value; }
    }

    public int Width
    {
        get { return width; }
        protected set { width = value; }
    }

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
    public void Draw()
    {
        DrawLine(this.Width, '*', '*');
        for (int i = 1; i < this.Height - 1; ++i)
        {
            DrawLine(this.Width, '*', ' ');
        }
        DrawLine(this.Width, '*', '*');
    }
    private void DrawLine(int width, char end, char middle)
    {
        Console.Write(end);
        for (int i = 1; i < width - 1; ++i)
        {
            Console.Write(middle);
        }
        Console.WriteLine(end);
    }
}

