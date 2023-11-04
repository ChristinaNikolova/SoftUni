using System;
using System.Collections.Generic;
using System.Linq;

namespace ChampionsLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> teamsAndWins = new Dictionary<string, int>();
            Dictionary<string, List<string>> teamsAndOpponents = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                string[] elements = input
                    .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string nameFirstTeam = elements[0];
                string nameSecondTeam = elements[1];

                bool isFirstAdded = teamsAndWins.ContainsKey(nameFirstTeam);
                if (!isFirstAdded)
                {
                    teamsAndWins.Add(nameFirstTeam, 0);
                    teamsAndOpponents.Add(nameFirstTeam, new List<string>());
                }

                bool isSecondAdded = teamsAndWins.ContainsKey(nameSecondTeam);
                if (!isSecondAdded)
                {
                    teamsAndWins.Add(nameSecondTeam, 0);
                    teamsAndOpponents.Add(nameSecondTeam, new List<string>());
                }

                teamsAndOpponents[nameFirstTeam].Add(nameSecondTeam);
                teamsAndOpponents[nameSecondTeam].Add(nameFirstTeam);

                int[] scoreFirstGame = elements[2]
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstTeamScoreFirstGame = scoreFirstGame[0];
                int secondTeamScoreFirstGame = scoreFirstGame[1];

                int[] scoreSecondGame = elements[3]
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int secondTeamScoreSecondGame = scoreSecondGame[0];
                int firstTeamScoreSecondGame = scoreSecondGame[1];

                int firstTotalResult = firstTeamScoreFirstGame + firstTeamScoreSecondGame;
                int secondTotalResult = secondTeamScoreFirstGame + secondTeamScoreSecondGame;

                if (firstTotalResult > secondTotalResult)
                {
                    teamsAndWins[nameFirstTeam]++;
                }
                else if (firstTotalResult < secondTotalResult)
                {
                    teamsAndWins[nameSecondTeam]++;
                }
                else
                {
                    if (secondTeamScoreFirstGame > firstTeamScoreSecondGame)
                    {
                        teamsAndWins[nameSecondTeam]++;
                    }
                    else if (secondTeamScoreFirstGame < firstTeamScoreSecondGame)
                    {
                        teamsAndWins[nameFirstTeam]++;
                    }
                }
            }

            Dictionary<string, int> sortedTeamsAndWins = teamsAndWins
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedTeamsAndWins)
            {
                string team = kvp.Key;
                int wins = kvp.Value;

                List<string> opponenets = teamsAndOpponents[team]
                    .OrderBy(x => x)
                    .ToList();

                Console.WriteLine(team);
                Console.WriteLine($"- Wins: {wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", opponenets)}");
            }
        }
    }
}
