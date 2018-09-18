using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable
{
    public List<T> items;

    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }
    public T Remove(int index)
    {
        var element = this.items[index];
        this.items.RemoveAt(index);

        return element;
    }
    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }
    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.items[firstIndex];
        this.items[firstIndex] = this.items[secondIndex];
        this.items[secondIndex] = firstElement;
    }
    public int CountGreaterThan(T element)
    {
        int count = 0;

        foreach (var item in this.items)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
    public T Max()
    {
        return this.items.Max();
    }
    public T Min()
    {
        return this.items.Min();
    }
    public void Sort()
    {
        this.items = this.items.OrderBy(a => a).ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var item in this.items)
        {
            result.AppendLine($"{item}");
        }

        return result.ToString().TrimEnd();
    }
}

