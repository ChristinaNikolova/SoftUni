using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> countriesCitiesAndCounts
                = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "report")
            {
                string[] elements = input
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string city = elements[0];
                string country = elements[1];
                long count = long.Parse(elements[2]);

                bool isCountryAdded = countriesCitiesAndCounts.ContainsKey(country);
                if (!isCountryAdded)
                {
                    countriesCitiesAndCounts.Add(country, new Dictionary<string, long>());
                }

                countriesCitiesAndCounts[country].Add(city, count);
            }

            Dictionary<string, Dictionary<string, long>> sortedCountriesCitiesAndCounts = countriesCitiesAndCounts
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedCountriesCitiesAndCounts)
            {
                string country = kvp.Key;
                Dictionary<string, long> citiesAndCounts = kvp.Value
                     .OrderByDescending(x => x.Value)
                     .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{country} (total population: {citiesAndCounts.Values.Sum()})");

                bool areAny = citiesAndCounts.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, citiesAndCounts
                        .Select(x => $"=>{x.Key}: {x.Value}")));
                }
            }
        }
    }
}
