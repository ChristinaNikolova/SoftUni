using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.rating = 0;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating => this.GetTheRating();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            int indexPlayer = this.players.FindIndex(x => x.Name == playerName);

            bool isValid = indexPlayer != -1;
            if (!isValid)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.RemoveAt(indexPlayer);
        }

        private double GetTheRating()
        {
            int playersCount = this.players.Count;

            bool isTeamEmpty = playersCount == 0;
            if (isTeamEmpty)
            {
                return this.rating = 0;
            }

            this.rating = Math.Round(this.players.Select(x => x.Stats).Sum() / playersCount);

            return this.rating;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
