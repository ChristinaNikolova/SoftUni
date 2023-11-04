using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRider> riders;
        private IRepository<IMotorcycle> motorcycles;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            IMotorcycle motorcycle = this.motorcycles.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {rider.Name} received motorcycle {motorcycle.Model}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IRider rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {rider.Name} added in {race.Name} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            motorcycle = this.motorcycles.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcycles.Add(motorcycle);

            return $"{type}Motorcycle {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = null;

            race = this.races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);
            this.races.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            IRider rider = null;

            rider = this.riders.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);
            this.riders.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            int racersCount = race.Riders.Count;

            if (racersCount < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            List<IRider> results = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            StringBuilder message = new StringBuilder();

            message.AppendLine($"Rider {results[0].Name} wins {race.Name} race.");
            message.AppendLine($"Rider {results[1].Name} is second in {race.Name} race.");
            message.Append($"Rider {results[2].Name} is third in {race.Name} race.");

            this.races.Remove(race);

            return message.ToString().TrimEnd();
        }
    }
}
