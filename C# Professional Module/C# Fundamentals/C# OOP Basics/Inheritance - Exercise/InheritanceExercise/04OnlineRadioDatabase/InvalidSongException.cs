using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException : Exception
{
    private string errorMessage = "Invalid song.";

    public virtual string ErrorMessage
    {
        set
        {
            this.errorMessage = value;
        }
    }
    public override string Message => errorMessage;
}
