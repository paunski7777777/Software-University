using System;
public class Mission : IMission
{
    public string CodeName { get; private set; }
    public State State { get; private set; }
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        ParseState(state);
    }

    private void ParseState(string state)
    {
        bool validState = Enum.TryParse(typeof(State), state, out object outState);
        if (!validState)
        {
            throw new ArgumentException("Invalid state!");
        }

        this.State = (State)outState;
    }

    public void Complete()
    {
        if (this.State == State.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }

        this.State = State.Finished;
    }
    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}

