using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class CustomStack<T> : IEnumerable<T>
{
    public Stack<T> MyStack { get; set; }
    public CustomStack()
    {
        this.MyStack = new Stack<T>();
    }

    public void Push(T number)
    {
        this.MyStack.Push(number);
    }
    public T Pop()
    {
        if (!this.MyStack.Any())
        {
            throw new ArgumentException("No elements");
        }

        var popedItem = this.MyStack.Peek();
        this.MyStack.Pop();

        return popedItem;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return this.MyStack.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

