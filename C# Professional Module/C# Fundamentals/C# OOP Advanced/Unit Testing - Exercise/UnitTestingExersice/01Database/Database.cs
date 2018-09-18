using System;
using System.Linq;

public class Database : ICustomCollection
{
    private const int Capacity = 16;
    private const string ArrayFullMessage = "Max capacity reached!";
    private const string ArrayEmptyMessage = "Array is empty! Cannot remove items!";

    public int[] Array { get; set; }
    public int Index { get; set; }

    public Database()
    {
        this.Array = new int[Capacity];
    }
    public Database(params int[] numbers)
            : this()
    {
        if (numbers != null)
        {
            foreach (var item in numbers)
            {
                this.Add(item);
            }
        }
    }
    public void Add(int number)
    {
        if (this.Index == this.Array.Length)
        {
            throw new InvalidOperationException(ArrayFullMessage);
        }
        this.Array[this.Index] = number;
        this.Index++;
    }

    public void Remove()
    {
        if (this.Index == 0)
        {
            throw new InvalidOperationException(ArrayEmptyMessage);
        }

        this.Index--;
    }

    public int[] Fetch()
    {
        return this.Array.Take(this.Index).ToArray();
    }
}