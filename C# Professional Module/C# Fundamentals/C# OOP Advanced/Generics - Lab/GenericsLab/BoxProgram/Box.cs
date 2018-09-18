using System.Collections.Generic;
using System.Linq;
public class Box<T>
{
    private List<T> items;

    public int Count => this.items.Count;
    public Box()
    {
        this.items = new List<T>();
    }

    public void Add(T item)
    {
        this.items.Add(item);
    }
    public T Remove()
    {
        var element = this.items.Last();
        this.items.RemoveAt(this.items.Count - 1);

        return element;
    }
}
