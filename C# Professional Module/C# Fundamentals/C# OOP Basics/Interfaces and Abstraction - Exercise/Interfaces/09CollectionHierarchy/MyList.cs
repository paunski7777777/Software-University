using System;
public class MyList : Collection, IAddable, IRemoveble, IUseble
{
    public int Used => base.MyCollection.Count;
    public override int Add(string item)
    {
        base.MyCollection.Insert(0, item);
        return 0;
    }
    public override string Remove()
    {
        var lastItem = base.MyCollection[0];
        base.MyCollection.RemoveAt(0);

        return lastItem;
    }
}

