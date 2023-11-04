using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Factories
{
    public static class PlayerFactory
    {
        public static Player Create(string[] elements)
        {
            string playerName = elements[2];
            int endurance = int.Parse(elements[3]);
            int sprint = int.Parse(elements[4]);
            int dribble = int.Parse(elements[5]);
            int passing = int.Parse(elements[6]);
            int shooting = int.Parse(elements[7]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            return player;
        }
    }
}
