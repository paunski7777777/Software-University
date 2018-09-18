using System;
public class AddRemoveCollection : Collection, IAddable, IRemoveble
{
    public AddRemoveCollection()
        : base()
    {

    }
    public override int Add(string item)
    {
        base.MyCollection.Insert(0, item);

        return 0;
    }
    public override string Remove()
    {
        var lastItem = base.MyCollection[base.MyCollection.Count - 1];
        base.MyCollection.RemoveAt(base.MyCollection.Count - 1);

        return lastItem;
    }
}

