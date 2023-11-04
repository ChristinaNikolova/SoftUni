using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private List<Fish> fishInPool;
        private string name;
        private int capacity;
        private int size;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
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

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        } 

        public void Add(Fish fish)
        {
            bool isFishAlreadyAdded = this.fishInPool.Any(x => x.Name == fish.Name);
            bool isFreeSpace = this.fishInPool.Count + 1 <= this.Capacity;

            if (!isFishAlreadyAdded && isFreeSpace)
            {
                this.fishInPool.Add(fish);
            }
        } 

        public bool Remove(string name)
        {
            bool isValid = this.fishInPool.Any(x => x.Name == name);
            if (!isValid)
            {
                return false;
            }

            int indexFish = this.fishInPool.FindIndex(x => x.Name == name);
            this.fishInPool.RemoveAt(indexFish);

            return true;
        } 

        public Fish FindFish(string name)
        {
            Fish fishToReturn = this.fishInPool
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return fishToReturn;
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (Fish fish in this.fishInPool)
            {
                message.AppendLine(fish.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
