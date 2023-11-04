using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        private string name;
        private string color;
        private int fins;

        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.color = value;
            }
        }

        public int Fins
        {
            get
            {
                return this.fins;
            }
            private set
            {
                this.fins = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Fish: {this.Name}")
                .AppendLine($"Color: {this.Color}")
                .Append($"Number of fins: {this.Fins}");

            return message.ToString();
        }
    }
}
