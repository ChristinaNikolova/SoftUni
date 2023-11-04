using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = elements[0];
                string pokemonName = elements[1];
                string pokemonElement = elements[2];
                int pokemonHealth = int.Parse(elements[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = null;

                bool isTrainerAdded = trainers.Any(x => x.Name == trainerName);
                if (isTrainerAdded)
                {
                    trainer = trainers
                        .Where(x => x.Name == trainerName)
                        .FirstOrDefault();

                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);

                    trainers.Add(trainer);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string currentElement = input;

                foreach (Trainer trainer in trainers)
                {
                    bool isFound = trainer.Pokemons.Any(x => x.Element == currentElement);
                    if (isFound)
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(x => x.BadgesCount)
                .ToList();

            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
