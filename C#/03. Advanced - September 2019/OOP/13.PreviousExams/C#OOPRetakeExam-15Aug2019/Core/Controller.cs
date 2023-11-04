using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded,
                type,
                astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded,
                planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitables = this.astronautRepository.Models
                 .Where(x => x.Oxygen > 60)
                 .ToList();

            if (suitables.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository
                .FindByName(planetName);

            this.mission.Explore(planet, suitables);

            this.exploredPlanetsCount++;

            int deadAstronauts = suitables
                .Where(x => x.Oxygen == 0)
                .Count();

            return string.Format(OutputMessages.PlanetExplored,
                planetName,
                deadAstronauts);
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"{this.exploredPlanetsCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astronautRepository.Models)
            {
                message.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count == 0)
                {
                    message.AppendLine("Bag items: none");
                }
                else
                {
                    message.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return message.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository
                .FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,
                    astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired,
                astronautName);
        }
    }
}
