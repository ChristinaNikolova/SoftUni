using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;

namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
