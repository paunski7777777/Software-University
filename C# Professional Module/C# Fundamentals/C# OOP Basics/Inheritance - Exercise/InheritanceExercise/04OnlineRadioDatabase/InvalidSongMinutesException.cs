using System;
using System.Collections.Generic;
using System.Text;
public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const int MIN_SONG_MINUTES = 0;
    private const int MAX_SONG_MINUTES = 14;

    public override string Message => $"Song minutes should be between {MIN_SONG_MINUTES} and {MAX_SONG_MINUTES}.";
}
