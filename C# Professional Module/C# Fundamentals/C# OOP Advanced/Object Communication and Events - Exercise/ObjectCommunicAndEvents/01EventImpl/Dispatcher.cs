public class Dispatcher : INameChangeable, INameable
{
    public event NameChangeEventHandler NameChange;

    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            this.name = value;
        }
    }

    public Dispatcher(string name)
    {
        this.name = name;
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if (this.NameChange != null)
        {
            this.NameChange.Invoke(this, args);
        }
    }
}