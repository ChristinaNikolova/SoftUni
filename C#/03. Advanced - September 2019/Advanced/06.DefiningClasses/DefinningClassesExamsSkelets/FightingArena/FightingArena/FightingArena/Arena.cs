using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        private string name;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
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

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        } 

        public void Remove(string name)
        {
            int index = this.gladiators.FindIndex(x => x.Name == name);

            if (index != -1)
            {
                this.gladiators.RemoveAt(index);
            }
        } 

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiatorToReturn = this.gladiators
                .OrderByDescending(x => x.GetStatPower())
                .FirstOrDefault();

            return gladiatorToReturn;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiatorToReturn = this.gladiators
                .OrderByDescending(x => x.GetWeaponPower())
                .FirstOrDefault();

            return gladiatorToReturn;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiatorToReturn = this.gladiators
                .OrderByDescending(x => x.GetTotalPower())
                .FirstOrDefault();

            return gladiatorToReturn;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.gladiators.Count} gladiators are participating.";
        }
    }
}
