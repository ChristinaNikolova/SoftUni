using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
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

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                this.level = value;
            }
        }

        public Item Item
        {
            get
            {
                return this.item;
            }
            private set
            {
                this.item = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Hero: {this.Name} - {this.Level}lvl");
            message.Append($"{this.Item.ToString()}");

            return message.ToString().TrimEnd();
        }
    }
}
