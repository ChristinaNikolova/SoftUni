using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards
                .Select(x => x.HealthPoints)
                .Sum();

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards
                .Select(x => x.HealthPoints)
                .Sum();

            while (!attackPlayer.IsDead)
            {
                int currentDamage = attackPlayer.CardRepository.Cards
                    .Select(x => x.DamagePoints)
                    .Sum();

                enemyPlayer.TakeDamage(currentDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                currentDamage = enemyPlayer.CardRepository.Cards
                    .Select(x => x.DamagePoints)
                    .Sum();

                attackPlayer.TakeDamage(currentDamage);
            }
        }
    }
}
