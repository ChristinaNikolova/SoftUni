using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesCount;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.BadgesCount = 0;
            this.pokemons = new List<Pokemon>();
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

        public int BadgesCount
        {
            get
            {
                return this.badgesCount;
            }
            set
            {
                this.badgesCount = value;
            }
        }

        public List<Pokemon> Pokemons
        {
            get
            {
                return this.pokemons;
            }
            private set
            {
                this.pokemons = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.BadgesCount} {this.pokemons.Count}";
        }
    }
}
