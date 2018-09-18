using System;
using System.Collections.Generic;
using System.Text;

class Rectangle
{
    public Point TopLeft { get; set; }

    public Point BottomRight { get; set; }

    public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        this.TopLeft = new Point(topLeftX, topLeftY);
        this.BottomRight = new Point(bottomRightX, bottomRightY);
    }

    public bool Contains(Point point)
    {
        bool isInHorizontal = this.TopLeft.X <= point.X && this.BottomRight.X >= point.X;
        bool isVertical = this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;

        bool isRectangle = isInHorizontal && isVertical;

        return isRectangle;
    }
}

