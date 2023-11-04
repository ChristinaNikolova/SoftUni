using FootballTeamGenerator.Factories;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Engine
    {
        public void Run()
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] elements = input
                    .Split(";")
                    .ToArray();

                    string command = elements[0];
                    string teamName = elements[1];

                    if (command == "Team")
                    {
                        CreateTeamCommand(teams, teamName);
                        continue;
                    }

                    int indexTeam = teams.FindIndex(x => x.Name == teamName);

                    bool isValid = indexTeam != -1;
                    if (!isValid)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    if (command == "Add")
                    {
                        AddPlayerCommand(teams, elements, indexTeam);
                    }
                    else if (command == "Remove")
                    {
                        RemovePlayerCommand(teams, elements, indexTeam);
                    }
                    else if (command == "Rating")
                    {
                        RatingCommand(teams, indexTeam);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddPlayerCommand(List<Team> teams, string[] elements, int indexTeam)
        {
            Player player = PlayerFactory.Create(elements);
            teams[indexTeam].AddPlayer(player);
        }

        private static void RemovePlayerCommand(List<Team> teams, string[] elements, int indexTeam)
        {
            string playerName = elements[2];
            teams[indexTeam].RemovePlayer(playerName);
        }

        private static void RatingCommand(List<Team> teams, int indexTeam)
        {
            Console.WriteLine(teams[indexTeam]);
        }

        private static void CreateTeamCommand(List<Team> teams, string teamName)
        {
            Team team = TeamFactory.Create(teamName);
            teams.Add(team);
        }
    }
}
