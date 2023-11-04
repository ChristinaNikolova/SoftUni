using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                while(astronaut.CanBreath && planet.Items.Any())
                {
                    string currentItem = planet.Items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
