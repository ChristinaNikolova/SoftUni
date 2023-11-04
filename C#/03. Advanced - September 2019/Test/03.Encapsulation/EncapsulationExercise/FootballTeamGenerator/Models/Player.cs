using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const int StatsCount = 5;
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.shooting = value;
            }
        }

        public double Stats => this.GetStats();

        private double GetStats()
        {
            double stats = 1.0 * (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / StatsCount;

            return stats;
        }
    }
}
