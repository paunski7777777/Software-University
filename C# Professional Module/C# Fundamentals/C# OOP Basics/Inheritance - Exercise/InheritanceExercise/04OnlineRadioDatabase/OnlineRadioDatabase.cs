using System;
using System.Collections.Generic;
using System.Linq;

public class OnlineRadioDatabase
{
    public static void Main()
    {
        var songs = new List<Song>();

        int countOfSongs = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfSongs; i++)
        {
            try
            {
                AddSongs(songs);
            }
            catch (InvalidSongException ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        PrintPlaylistDuration(songs);
    }

    private static void PrintPlaylistDuration(List<Song> songs)
    {
        int totalDuration = songs.Sum(s => s.Minutes * 60 + s.Seconds);
        int hours = totalDuration / 60 / 60;
        int minutes = (totalDuration / 60) - (hours * 60);
        long seconds = totalDuration % 60;

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }

    private static void AddSongs(List<Song> songs)
    {
        string[] tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        string artistName = tokens[0];
        string songName = tokens[1];
        string[] time = tokens[2].Split(':');

        if (int.TryParse(time[0], out int minutes) && int.TryParse(time[1], out int seconds))
        {
            if (minutes * 60 + seconds > 0 || minutes * 60 + seconds < 14 * 60 + 59)
            {
                Song song = new Song(artistName, songName, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
        }
        else
        {
            throw new InvalidSongLengthException();
        }
    }
}

