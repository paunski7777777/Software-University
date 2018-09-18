using System.Collections.Generic;

public class GenericBox<T>
{
    private List<T> items;
    public GenericBox()
    {
        this.items = new List<T>();
    }
    public void Add(T item)
    {
        this.items.Add(item);
    }

    public override string ToString()
    {

        return $"{typeof(T).FullName}: {string.Join(" ", this.items)}";
    }
}

