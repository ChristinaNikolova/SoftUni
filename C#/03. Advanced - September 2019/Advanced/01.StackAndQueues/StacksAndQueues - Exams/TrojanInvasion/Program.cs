using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToBuildExtraPlate = 3;

            bool trojanWins = false;

            int totalWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> warriors = null;

            for (int currentWave = 1; currentWave <= totalWaves; currentWave++)
            {
                warriors = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

                bool isExtraPlate = currentWave % numberToBuildExtraPlate == 0;
                if (isExtraPlate)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Add(extraPlate);
                }

                while (plates.Any() && warriors.Any())
                {
                    int currentWarrior = warriors.Pop();

                    int currentPlate = plates[0];
                    plates.RemoveAt(0);

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                        plates.Insert(0, currentPlate);
                    }
                }

                bool arePlates = plates.Any();
                if (!arePlates)
                {
                    trojanWins = true;
                    break;
                }
            }

            if (trojanWins)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
