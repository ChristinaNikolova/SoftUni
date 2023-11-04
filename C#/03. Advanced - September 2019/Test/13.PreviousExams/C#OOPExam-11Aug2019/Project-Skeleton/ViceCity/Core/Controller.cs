using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private IRepository<IGun> gunRepository;
        private INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.gunRepository.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.gunRepository.Models.First();

            if (name.EndsWith("Vercetti"))
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            IPlayer player = this.civilPlayers
                .FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);
            this.gunRepository.Remove(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerLifePointsBeforeFight = this.mainPlayer.LifePoints;

            int totalCivilPlayersBeforeFight = this.civilPlayers.Count;

            int totalHeathCivilPlayersBeforeFight = this.civilPlayers
                .Select(x => x.LifePoints)
                .Sum();

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int leftCivilPlayers = this.civilPlayers.Count;

            int leftHeathCivilPlayers = this.civilPlayers
                .Select(x => x.LifePoints)
                .Sum();

            if (this.mainPlayer.LifePoints == mainPlayerLifePointsBeforeFight
                && totalCivilPlayersBeforeFight == leftCivilPlayers
                && totalHeathCivilPlayersBeforeFight == leftHeathCivilPlayers)
            {
                return "Everything is okay!";
            }

            StringBuilder message = new StringBuilder();

            int deadCivilPlayers = totalCivilPlayersBeforeFight - leftCivilPlayers;

            message.AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {deadCivilPlayers} players!")
                .Append($"Left Civil Players: {leftCivilPlayers}!");

            return message.ToString().TrimEnd();
        }
    }
}
