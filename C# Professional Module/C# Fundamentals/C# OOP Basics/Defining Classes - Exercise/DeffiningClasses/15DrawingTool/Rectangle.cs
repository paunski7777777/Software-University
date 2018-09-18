using System;
using System.Collections.Generic;
using System.Text;
class Rectangle : CorDraw
{
    public int A { get; set; }
    public int B { get; set; }
    public Rectangle(int a, int b)
    {
        this.A = a;
        this.B = b;
    }
    public override void Draw()
    {
        StringBuilder result = new StringBuilder();
        result.Append("|").Append(new string('-', this.A)).AppendLine("|");
        for (int i = 0; i < this.B - 2; i++)
        {
            result.Append("|").Append(new string(' ', this.A)).AppendLine("|");
        }
        if (this.B > 1)
        {
            result.Append("|").Append(new string('-', this.A)).AppendLine("|");
        }
        Console.Write(result.ToString());
    }
}

