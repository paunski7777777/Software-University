using System;
using System.Collections.Generic;
public class StackOfStrings
{
    private List<string> data = new List<string>();
    public void Push(string item)
    {
        data.Add(item);
    }
    public bool IsEmpty()
    {
        return data.Count == 0;
    }
    public string Peek()
    {
        string result = string.Empty;

        if (!IsEmpty())
        {
            result = data[data.Count - 1];
        }

        return result;
    }
    public string Pop()
    {
        string result = string.Empty;

        if (!IsEmpty())
        {
            int lastIndex = data.Count - 1;
            result = data[lastIndex];
            data.RemoveAt(lastIndex);
        }

        return result;
    }
}

