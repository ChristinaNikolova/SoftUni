using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelMap
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> countriesCitiesCosts
                = new SortedDictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" > ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string country = elements[0];
                string town = elements[1];
                int costs = int.Parse(elements[2]);

                bool isCountryAdded = countriesCitiesCosts.ContainsKey(country);
                if (!isCountryAdded)
                {
                    countriesCitiesCosts.Add(country, new Dictionary<string, int>());
                }

                bool isTownAdded = countriesCitiesCosts[country].ContainsKey(town);
                if (!isTownAdded)
                {
                    countriesCitiesCosts[country].Add(town, costs);
                }
                else
                {
                    bool isCheaper = countriesCitiesCosts[country][town] > costs;
                    if (isCheaper)
                    {
                        countriesCitiesCosts[country][town] = costs;
                    }
                }
            }

            foreach (var kvp in countriesCitiesCosts)
            {
                string country = kvp.Key;
                Dictionary<string, int> townsAndCosts = kvp.Value
                    .OrderBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{country} -> {string.Join(" ", townsAndCosts.Select(x => $"{x.Key} -> {x.Value}"))}");
            }
        }
    }
}
