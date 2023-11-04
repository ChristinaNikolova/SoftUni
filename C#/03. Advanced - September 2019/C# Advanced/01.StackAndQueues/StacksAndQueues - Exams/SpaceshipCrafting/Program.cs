using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materialsAndPoints = new Dictionary<string, int>();

            materialsAndPoints.Add("Glass", 25);
            materialsAndPoints.Add("Aluminium", 50);
            materialsAndPoints.Add("Lithium", 75);
            materialsAndPoints.Add("Carbon fiber", 100);

            SortedDictionary<string, int> materialsAndCounts = new SortedDictionary<string, int>();

            materialsAndCounts.Add("Glass", 0);
            materialsAndCounts.Add("Aluminium", 0);
            materialsAndCounts.Add("Lithium", 0);
            materialsAndCounts.Add("Carbon fiber", 0);

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> items = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (liquids.Any() && items.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                int sum = currentLiquid + currentItem;

                bool isMade = materialsAndPoints.Any(x => x.Value == sum);
                if (isMade)
                {
                    string currentMaterial = materialsAndPoints
                        .Where(x => x.Value == sum)
                        .FirstOrDefault()
                        .Key;

                    materialsAndCounts[currentMaterial]++;
                }
                else
                {
                    currentItem += 3;
                    items.Push(currentItem);
                }
            }

            bool isSuccess = materialsAndCounts.All(x => x.Value > 0);
            if (isSuccess)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            bool areLiquids = liquids.Any();
            if (areLiquids)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            bool areItems = items.Any();
            if (areItems)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine(string.Join(Environment.NewLine, materialsAndCounts
                .Select(x => $"{x.Key}: {x.Value}")));
        }
    }
}
