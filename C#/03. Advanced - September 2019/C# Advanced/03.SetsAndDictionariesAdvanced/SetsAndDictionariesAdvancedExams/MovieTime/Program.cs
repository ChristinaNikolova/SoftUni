using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, TimeSpan>> genreMovieDuration
                = new Dictionary<string, Dictionary<string, TimeSpan>>();

            string favoriteGenre = Console.ReadLine();
            string favoriteDuration = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                string[] elements = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string movieName = elements[0];
                string genre = elements[1];
                TimeSpan duration = TimeSpan.Parse(elements[2]);

                bool isGenreAdded = genreMovieDuration.ContainsKey(genre);
                if (!isGenreAdded)
                {
                    genreMovieDuration.Add(genre, new Dictionary<string, TimeSpan>());
                }

                bool isMovieAdded = genreMovieDuration[genre].ContainsKey(movieName);
                if (!isMovieAdded)
                {
                    genreMovieDuration[genre].Add(movieName, duration);
                }
            }

            Dictionary<string, TimeSpan> bestSelection = null;

            if (favoriteDuration == "Short")
            {
                bestSelection = genreMovieDuration[favoriteGenre]
                    .OrderBy(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else if (favoriteDuration == "Long")
            {
                bestSelection = genreMovieDuration[favoriteGenre]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }

            foreach (var kvp in bestSelection)
            {
                string movieName = kvp.Key;
                TimeSpan duration = kvp.Value;

                Console.WriteLine(movieName);

                string answer = Console.ReadLine();

                bool isWifeHappy = answer == "Yes";
                if (isWifeHappy)
                {
                    Console.WriteLine($"We're watching {movieName} - {duration}");

                    double totalSecond = genreMovieDuration
                        .Select(x => x.Value.Sum(y => y.Value.TotalSeconds))
                        .Sum();

                    TimeSpan finalOutput = TimeSpan.FromSeconds(totalSecond);

                    Console.WriteLine($"Total Playlist Duration: {finalOutput}");
                    break;
                }
            }
        }
    }
}
