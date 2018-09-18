using System;
using System.Collections.Generic;
public abstract class Collection : IAddable, IRemoveble
{
    private IList<string> myCollection;

    public IList<string> MyCollection
    {
        get { return myCollection; }
        set { myCollection = value; }
    }

    public Collection()
    {
        this.MyCollection = new List<string>();
    }
    public abstract int Add(string item);
    public abstract string Remove();
}

