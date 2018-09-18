using System;
public class NameChangeEventArgs : EventArgs
{
    public string Name { get; }
    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }
}