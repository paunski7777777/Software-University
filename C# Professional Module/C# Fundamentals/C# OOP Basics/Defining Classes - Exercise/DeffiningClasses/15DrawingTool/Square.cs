using System;
using System.Collections.Generic;
using System.Text;
class Square : CorDraw
{
    public int Size { get; set; }
    public Square(int size)
    {
        this.Size = size;
    }
    public override void Draw()
    {
        StringBuilder result = new StringBuilder();

        result.Append("|").Append(new string('-', this.Size)).AppendLine("|");
        for (int i = 0; i < this.Size - 2; i++)
        {
            result.Append("|").Append(new string(' ', this.Size)).AppendLine("|");
        }
        if (this.Size > 1)
        {
            result.Append("|").Append(new string('-', this.Size)).AppendLine("|");
        }
        Console.Write(result.ToString());
    }
}

