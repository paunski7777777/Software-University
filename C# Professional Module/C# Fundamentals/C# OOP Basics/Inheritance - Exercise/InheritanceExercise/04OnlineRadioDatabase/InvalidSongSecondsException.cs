using System;
using System.Collections.Generic;
using System.Text;
public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const int MIN_SONG_SECONDS = 0;
    private const int MAX_SONG_SECONDS = 59;

    public override string Message => $"Song seconds should be between {MIN_SONG_SECONDS} and {MAX_SONG_SECONDS}.";
}

