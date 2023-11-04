using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Any() && civilPlayers.Any())
            {
                IGun gun = mainPlayer.GunRepository.Models.First();
                IPlayer player = civilPlayers.First();

                while(gun.CanFire && player.IsAlive)
                {
                    int currentPoints = gun.Fire();
                    player.TakeLifePoints(currentPoints);
                }

                if (!gun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(gun);
                }

                if (!player.IsAlive)
                {
                    civilPlayers.Remove(player);
                }
            }

            foreach (IPlayer player in civilPlayers)
            {
                while (player.GunRepository.Models.Any())
                {
                    IGun gun = player.GunRepository.Models.First();

                    while(gun.CanFire && mainPlayer.IsAlive)
                    {
                        int currentPoints = gun.Fire();
                        mainPlayer.TakeLifePoints(currentPoints);
                    }

                    if (!gun.CanFire)
                    {
                        player.GunRepository.Remove(gun);
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        return;
                    }
                }
            }
        }
    }
}
