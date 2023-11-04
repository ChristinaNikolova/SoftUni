using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Factories
{
    public static class TeamFactory
    {
        public static Team Create(string teamName)
        {
            Team team = new Team(teamName);

            return team;
        }
    }
}
