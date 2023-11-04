using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] elements = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = elements[0];
                string password = elements[1];

                contestsAndPasswords.Add(contest, password);
            }

            SortedDictionary<string, Dictionary<string, int>> usersContestsPoints
                = new SortedDictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] elements = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = elements[0];
                string password = elements[1];
                string username = elements[2];
                int points = int.Parse(elements[3]);

                bool isContestValid = contestsAndPasswords.ContainsKey(contest);
                if (!isContestValid)
                {
                    continue;
                }

                bool isPasswordCorrect = contestsAndPasswords[contest] == password;
                if (!isPasswordCorrect)
                {
                    continue;
                }

                bool isUserAdded = usersContestsPoints.ContainsKey(username);
                if (!isUserAdded)
                {
                    usersContestsPoints.Add(username, new Dictionary<string, int>());
                }

                bool isContestAdded = usersContestsPoints[username].ContainsKey(contest);
                if (!isContestAdded)
                {
                    usersContestsPoints[username].Add(contest, points);
                }
                else
                {
                    bool isHeigherResult = usersContestsPoints[username][contest] < points;
                    if (isHeigherResult)
                    {
                        usersContestsPoints[username][contest] = points;
                    }
                }
            }

            string bestStudent = usersContestsPoints
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault()
                .Key;

            Console.WriteLine($"Best candidate is {bestStudent} with total {usersContestsPoints[bestStudent].Values.Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var kvp in usersContestsPoints)
            {
                string user = kvp.Key;
                Dictionary<string, int> contestsAndPoints = kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine(user);

                bool areAny = contestsAndPoints.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, contestsAndPoints
                        .Select(x => $"#  {x.Key} -> {x.Value}")));
                }
            }
        }
    }
}
