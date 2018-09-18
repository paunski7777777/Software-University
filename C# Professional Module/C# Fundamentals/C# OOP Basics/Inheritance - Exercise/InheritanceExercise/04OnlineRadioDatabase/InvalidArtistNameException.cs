using System;
using System.Collections.Generic;
using System.Text;
public class InvalidArtistNameException : InvalidSongException
{
    private const int MIN_ARTIST_NAME_LENGTH = 3;
    private const int MAX_ARTIST_NAME_LENGTH = 20;
    public override string Message
        => $"Artist name should be between {MIN_ARTIST_NAME_LENGTH} and {MAX_ARTIST_NAME_LENGTH} symbols.";
}

