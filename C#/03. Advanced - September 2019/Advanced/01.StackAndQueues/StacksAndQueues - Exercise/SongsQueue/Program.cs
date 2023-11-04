using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Add")
                {
                    string[] songsProps = elements.Skip(1).ToArray();
                    string currentSong = string.Join(" ", songsProps);

                    bool isAdded = songs.Contains(currentSong);
                    if (isAdded)
                    {
                        Console.WriteLine($"{currentSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(currentSong);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
