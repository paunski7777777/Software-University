using System;
using System.Collections.Generic;
using System.Text;
public class InvalidSongLengthException : InvalidSongException
{
    public override string Message => "Invalid song length.";
}

