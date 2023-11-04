using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;
        private string name;
        private int capacity;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
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

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            int index = this.data.FindIndex(x => x.Name == name);

            if (index== -1)
            {
                return false;
            }

            this.data.RemoveAt(index);

            return true;
        } 

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(x => x.Name == name);

            rabbit.Available = false;

            return rabbit;
        } 

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> rabbits = new List<Rabbit>();

            foreach (Rabbit rabbit in this.data)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    rabbits.Add(rabbit);
                }
            }

            return rabbits.ToArray();
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Rabbits available at {this.Name}:");

            foreach (Rabbit rabbit in this.data)
            {
                if (rabbit.Available == true)
                {
                    message.AppendLine(rabbit.ToString());
                }
            }

            return message.ToString().TrimEnd();
        }
    }
}
