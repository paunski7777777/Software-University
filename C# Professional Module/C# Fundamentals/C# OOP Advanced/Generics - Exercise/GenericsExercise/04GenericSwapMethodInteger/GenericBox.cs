using System.Collections.Generic;
using System.Text;
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
    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.items[firstIndex];
        this.items[firstIndex] = this.items[secondIndex];
        this.items[secondIndex] = firstElement;
    }
    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var item in this.items)
        {
            result.AppendLine($"{item.GetType().FullName}: {item}");
        }

        return result.ToString().TrimEnd();
    }
}

