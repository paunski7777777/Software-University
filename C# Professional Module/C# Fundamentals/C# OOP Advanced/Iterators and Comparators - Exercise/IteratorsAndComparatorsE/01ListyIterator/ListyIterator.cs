using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class ListyIterator<T> : IEnumerable<T>
{
    private const string ERROR_MESSAGE = "Invalid Operation!";
    public List<T> Items { get; set; }
    public int CurrentIndex { get; set; }
    public ListyIterator()
    {
        this.Items = new List<T>();
        this.CurrentIndex = 0;
    }

    public void Create(List<T> items)
    {
        if (items.Count < 1)
        {
            throw new ArgumentException(ERROR_MESSAGE);
        }

        items.ForEach(i => this.Items.Add(i));
    }
    public bool Move()
    {
        if (HasNext())
        {
            this.CurrentIndex++;
            return true;
        }

        return false;
    }
    public bool HasNext()
    {
        return this.CurrentIndex + 1 < this.Items.Count;
    }
    public void Print()
    {
        if (this.Items.Any())
        {
            Console.WriteLine(this.Items[this.CurrentIndex]);
        }
    }
    public string PrintAll()
    {
        var sb = new StringBuilder();

        foreach (var item in this.Items)
        {
            sb.Append($"{item} ");
        }

        string result = sb.ToString().Trim();

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Items.Count; i++)
        {
            yield return this.Items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
