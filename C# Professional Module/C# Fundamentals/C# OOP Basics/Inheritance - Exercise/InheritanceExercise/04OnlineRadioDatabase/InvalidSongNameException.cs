using System;
using System.Collections.Generic;
using System.Text;
public class InvalidSongNameException : InvalidSongException
{
    private const int MIN_SONG_NAME_LENGTH = 3;
    private const int MAX_SONG_NAME_LENGTH = 30;
    public override string Message
        => $"Song name should be between {MIN_SONG_NAME_LENGTH} and {MAX_SONG_NAME_LENGTH} symbols.";
}

