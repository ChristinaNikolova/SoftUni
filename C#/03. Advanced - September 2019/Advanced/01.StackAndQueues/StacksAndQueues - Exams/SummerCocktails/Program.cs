using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> cocktailsAndPoints = new Dictionary<string, int>();

            cocktailsAndPoints.Add("Mimosa", 150);
            cocktailsAndPoints.Add("Daiquiri", 250);
            cocktailsAndPoints.Add("Sunshine", 300);
            cocktailsAndPoints.Add("Mojito", 400);

            SortedDictionary<string, int> cocktailsAndCounts = new SortedDictionary<string, int>();

            cocktailsAndCounts.Add("Mimosa", 0);
            cocktailsAndCounts.Add("Daiquiri", 0);
            cocktailsAndCounts.Add("Sunshine", 0);
            cocktailsAndCounts.Add("Mojito", 0);

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            while (ingredients.Any() && freshness.Any())
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();

                int product = currentIngredient * currentFreshness;

                bool isMade = cocktailsAndPoints.Any(x => x.Value == product);
                if (isMade)
                {
                    string currentCocktail = cocktailsAndPoints
                        .Where(x => x.Value == product)
                        .FirstOrDefault()
                        .Key;

                    cocktailsAndCounts[currentCocktail]++;
                }
                else
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            bool isSuccess = cocktailsAndCounts.All(x => x.Value > 0);
            if (isSuccess)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            bool areIngredients = ingredients.Any();
            if (areIngredients)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var kvp in cocktailsAndCounts)
            {
                string currentCocktail = kvp.Key;
                int count = kvp.Value;

                bool hasToPrint = count > 0;
                if (hasToPrint)
                {
                    Console.WriteLine($" # {currentCocktail} --> {count}");
                }
            }
        }
    }
}
