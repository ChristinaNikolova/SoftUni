using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> usersTagsLikes = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input.Contains("->"))
                {
                    string[] elements = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string username = elements[0];
                    string tag = elements[1];
                    int likes = int.Parse(elements[2]);

                    bool isUsernameAdded = usersTagsLikes.ContainsKey(username);
                    if (!isUsernameAdded)
                    {
                        usersTagsLikes.Add(username, new Dictionary<string, int>());
                    }

                    bool isTagAdded = usersTagsLikes[username].ContainsKey(tag);
                    if (!isTagAdded)
                    {
                        usersTagsLikes[username].Add(tag, 0);
                    }

                    usersTagsLikes[username][tag] += likes;
                }
                else
                {
                    string[] elements = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string username = elements[1];

                    bool isAdded = usersTagsLikes.ContainsKey(username);
                    if (isAdded)
                    {
                        usersTagsLikes.Remove(username);
                    }
                }
            }

            Dictionary<string, Dictionary<string, int>> sortedUsersTagsLikes = usersTagsLikes
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Value.Keys.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedUsersTagsLikes)
            {
                string user = kvp.Key;
                Dictionary<string, int> tagsAndLikes = kvp.Value;

                Console.WriteLine(user);

                bool areAny = tagsAndLikes.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, tagsAndLikes
                        .Select(x => $"- {x.Key}: {x.Value}")));
                }
            }
        }
    }
}
