using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                this.strength = value;
            }
        }

        public int Ability
        {
            get
            {
                return this.ability;
            }
            private set
            {
                this.ability = value;
            }
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            private set
            {
                this.intelligence = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("Item:")
                .AppendLine($"  * Strength: {this.Strength}")
                .AppendLine($"  * Ability: {this.Ability}")
                .Append($"  * Intelligence: {this.Intelligence}");

            return message.ToString();
        }

    }
}
