using System;
using System.Collections.Generic;

public class GenericBox<T>
    where T : IComparable
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
    public int CompareItems(T itemToCompare)
    {
        int count = 0;

        foreach (var item in this.items)
        {
            if (item.CompareTo(itemToCompare) > 0)
            {
                count++;
            }
        }

        return count;
    }
}

