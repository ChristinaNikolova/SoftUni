using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;
        private string name;
        private int capacity;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
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

        public void Add(Astronaut astronaut)
        {
            bool isFreeSpace = this.data.Count + 1 <= this.Capacity;
            if (isFreeSpace)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            bool isFound = this.data.Any(x => x.Name == name);
            if (!isFound)
            {
                return false;
            }

            int indexAstronaut = this.data.FindIndex(x => x.Name == name);
            this.data.RemoveAt(indexAstronaut);

            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstronaut = this.data
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronautToReturn = this.data
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return astronautToReturn;
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (Astronaut astronaut in this.data)
            {
                message.AppendLine(astronaut.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
