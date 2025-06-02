using System;
using System.Collections.Generic;
using System.Linq;

public class MyPlayList : IPlaylist
{
    public static List<Song> myPlayList = new List<Song>();
    private int capacity;

    public MyPlayList()
    {
        capacity = 20;
    }

    public void Add(Song song)
    {
        List<string> allowedGenres = new List<string> {
            "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic"
        };

        if (myPlayList.Count >= capacity)
        {
            Console.WriteLine("Playlist is full. Cannot add more songs.");
            return;
        }

        if (!allowedGenres.Contains(song.SongGenre))
        {
            Console.WriteLine("Invalid Genre. Please enter a valid genre.");
            return;
        }

        myPlayList.Add(song);
        Console.WriteLine("Song added successfully.");
    }

    public void Remove(int SongId)
    {
        Song song = myPlayList.FirstOrDefault(s => s.SongId == SongId);
        if (song != null)
        {
            myPlayList.Remove(song);
            Console.WriteLine("Song removed successfully.");
        }
        else
        {
            Console.WriteLine("Song with the given ID not found.");
        }
    }

    public Song GetSongById(int songId)
    {
        return myPlayList.FirstOrDefault(s => s.SongId == songId);
    }

    public Song GetSongByName(string songName)
    {
        return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
    }

    public List<Song> GetAllSongs()
    {
        return myPlayList;
    }
}
