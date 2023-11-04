using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double DefaultDecreaseOxygen = 5;
        public Biologist(string name) 
            : base(name, 70)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - DefaultDecreaseOxygen > 0)
            {
                this.Oxygen -= DefaultDecreaseOxygen;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
