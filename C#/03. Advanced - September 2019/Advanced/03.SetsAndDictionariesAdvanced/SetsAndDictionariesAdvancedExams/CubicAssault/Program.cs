using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> regionsWarriorsAndCounts
                = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Count em all")
            {
                string[] elements = input
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string regionName = elements[0];
                string meteorType = elements[1];
                long count = long.Parse(elements[2]);

                bool isRegionAdded = regionsWarriorsAndCounts.ContainsKey(regionName);
                if (!isRegionAdded)
                {
                    regionsWarriorsAndCounts.Add(regionName, new Dictionary<string, long>());

                    regionsWarriorsAndCounts[regionName].Add("Green", 0);
                    regionsWarriorsAndCounts[regionName].Add("Red", 0);
                    regionsWarriorsAndCounts[regionName].Add("Black", 0);
                }

                regionsWarriorsAndCounts[regionName][meteorType] += count;

                if (regionsWarriorsAndCounts[regionName]["Green"] >= 1_000_000)
                {
                    regionsWarriorsAndCounts[regionName]["Red"] += regionsWarriorsAndCounts[regionName]["Green"] / 1_000_000;
                    regionsWarriorsAndCounts[regionName]["Green"] = regionsWarriorsAndCounts[regionName]["Green"] % 1_000_000;
                }

                if (regionsWarriorsAndCounts[regionName]["Red"] >= 1_000_000)
                {
                    regionsWarriorsAndCounts[regionName]["Black"] += regionsWarriorsAndCounts[regionName]["Red"] / 1_000_000;
                    regionsWarriorsAndCounts[regionName]["Red"] = regionsWarriorsAndCounts[regionName]["Red"] % 1_000_000;
                }
            }

            Dictionary<string, Dictionary<string, long>> sortedRegionsWarriorsAndCounts = regionsWarriorsAndCounts
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedRegionsWarriorsAndCounts)
            {
                string region = kvp.Key;
                Dictionary<string, long> warriorsAndCounts = kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine(region);
                Console.WriteLine(string.Join(Environment.NewLine, warriorsAndCounts
                    .Select(x => $"-> {x.Key} : {x.Value}")));
            }
        }
    }
}
