using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsCountriesCities
                = new Dictionary<string, Dictionary<string, List<string>>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = elements[0];
                string country = elements[1];
                string city = elements[2];

                bool isContinentAdded = continentsCountriesCities.ContainsKey(continent);
                if (!isContinentAdded)
                {
                    continentsCountriesCities.Add(continent, new Dictionary<string, List<string>>());
                }

                bool isCountryAdded = continentsCountriesCities[continent].ContainsKey(country);
                if (!isCountryAdded)
                {
                    continentsCountriesCities[continent].Add(country, new List<string>());
                }

                continentsCountriesCities[continent][country].Add(city);
            }

            foreach (var (continent, countriesAndCities) in continentsCountriesCities)
            {
                Console.WriteLine($"{continent}:");

                bool areAny = countriesAndCities.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, countriesAndCities
                        .Select(x => $"  {x.Key} -> {string.Join(", ", x.Value)}")));
                }
            }
        }
    }
}
