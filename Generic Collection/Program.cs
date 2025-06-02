using System;

class Program
{
    static void Main(string[] args)
    {
        MyPlayList playlist = new MyPlayList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEnter 1: To Add Song\nEnter 2: To Remove Song by Id\nEnter 3: Get Song By Id\nEnter 4: Get Song by Name\nEnter 5: Get All Songs from Playlist\nEnter 6: Exit");
            Console.Write("Your Choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Song newSong = new Song();

                    Console.Write("Enter Song ID: ");
                    newSong.SongId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Song Name: ");
                    newSong.SongName = Console.ReadLine();

                    Console.Write("Enter Song Genre (Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic): ");
                    newSong.SongGenre = Console.ReadLine();

                    playlist.Add(newSong);
                    break;

                case "2":
                    Console.Write("Enter Song ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    playlist.Remove(removeId);
                    break;

                case "3":
                    Console.Write("Enter Song ID to get details: ");
                    int getId = int.Parse(Console.ReadLine());
                    Song songById = playlist.GetSongById(getId);
                    if (songById != null)
                        Console.WriteLine($"ID: {songById.SongId}, Name: {songById.SongName}, Genre: {songById.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case "4":
                    Console.Write("Enter Song Name to get details: ");
                    string getName = Console.ReadLine();
                    Song songByName = playlist.GetSongByName(getName);
                    if (songByName != null)
                        Console.WriteLine($"ID: {songByName.SongId}, Name: {songByName.SongName}, Genre: {songByName.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case "5":
                    var allSongs = playlist.GetAllSongs();
                    if (allSongs.Count == 0)
                    {
                        Console.WriteLine("No songs in the playlist.");
                    }
                    else
                    {
                        foreach (var song in allSongs)
                        {
                            Console.WriteLine($"ID: {song.SongId}, Name: {song.SongName}, Genre: {song.SongGenre}");
                        }
                    }
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
