﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool available;

        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
            this.Available = true;
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

        public string Species
        {
            get
            {
                return this.species;
            }
            private set
            {
                this.species = value;
            }
        }

        public bool Available
        {
            get
            {
                return this.available;
            }
            set
            {
                this.available = value;
            }
        }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
