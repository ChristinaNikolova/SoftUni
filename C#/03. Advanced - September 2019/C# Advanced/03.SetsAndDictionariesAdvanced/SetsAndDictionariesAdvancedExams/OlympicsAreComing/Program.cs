using System;
using System.Collections.Generic;
using System.Linq;

namespace OlympicsAreComing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> countriesAthletesWins = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "report")
            {
                string[] elements = input
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string[] athleteProps = elements[0]
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string athleteName = string.Join(" ", athleteProps);

                string[] countryProps = elements[1]
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string country = string.Join(" ", countryProps);

                bool isCountryAdded = countriesAthletesWins.ContainsKey(country);
                if (!isCountryAdded)
                {
                    countriesAthletesWins.Add(country, new Dictionary<string, int>());
                }

                bool isAthleteAdded = countriesAthletesWins[country].ContainsKey(athleteName);
                if (!isAthleteAdded)
                {
                    countriesAthletesWins[country].Add(athleteName, 0);
                }

                countriesAthletesWins[country][athleteName]++;
            }

            Dictionary<string, Dictionary<string, int>> sortedCountriesAthletesWins = countriesAthletesWins
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedCountriesAthletesWins)
            {
                string country = kvp.Key;
                Dictionary<string, int> athletesAndWins = kvp.Value;

                Console.WriteLine($"{country} ({athletesAndWins.Count} participants): {athletesAndWins.Values.Sum()} wins");
            }
        }
    }
}
