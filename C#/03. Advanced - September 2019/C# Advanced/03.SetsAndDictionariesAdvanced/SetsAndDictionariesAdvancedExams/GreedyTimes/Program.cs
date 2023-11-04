using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> resoursesTypesAndQuantities
                = new Dictionary<string, Dictionary<string, long>>();

            resoursesTypesAndQuantities.Add("Gold", new Dictionary<string, long>());
            resoursesTypesAndQuantities.Add("Gem", new Dictionary<string, long>());
            resoursesTypesAndQuantities.Add("Cash", new Dictionary<string, long>());

            long bagCapacity = long.Parse(Console.ReadLine());

            string[] inputLine = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < inputLine.Length; i += 2)
            {
                string currentItem = inputLine[i];
                long quantity = long.Parse(inputLine[i + 1]);

                long totalGold = resoursesTypesAndQuantities["Gold"].Values.Sum();
                long totalGem = resoursesTypesAndQuantities["Gem"].Values.Sum();
                long totalCash = resoursesTypesAndQuantities["Cash"].Values.Sum();

                long totalSum = totalGold + totalGem + totalCash;

                bool isSpaceEnough = totalSum + quantity <= bagCapacity;
                if (!isSpaceEnough)
                {
                    continue;
                }

                if (currentItem.ToLower().EndsWith("gem") && currentItem.Length >= 4)
                {
                    bool isValid = totalGem + quantity <= totalGold;
                    if (!isValid)
                    {
                        continue;
                    }

                    bool isAdded = resoursesTypesAndQuantities["Gem"].ContainsKey(currentItem);
                    if (!isAdded)
                    {
                        resoursesTypesAndQuantities["Gem"].Add(currentItem, 0);
                    }

                    resoursesTypesAndQuantities["Gem"][currentItem] += quantity;
                }
                else if (currentItem.ToLower() == "gold")
                {
                    bool isAdded = resoursesTypesAndQuantities["Gold"].ContainsKey(currentItem);
                    if (!isAdded)
                    {
                        resoursesTypesAndQuantities["Gold"].Add(currentItem, 0);
                    }

                    resoursesTypesAndQuantities["Gold"][currentItem] += quantity;
                }
                else if (currentItem.Length == 3)
                {
                    bool isValid = totalCash + quantity <= totalGem;
                    if (!isValid)
                    {
                        continue;
                    }

                    bool isAdded = resoursesTypesAndQuantities["Cash"].ContainsKey(currentItem);
                    if (!isAdded)
                    {
                        resoursesTypesAndQuantities["Cash"].Add(currentItem, 0);
                    }

                    resoursesTypesAndQuantities["Cash"][currentItem] += quantity;
                }
            }

            Dictionary<string, Dictionary<string, long>> sortedResoursesTypesAndQuantities = resoursesTypesAndQuantities
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedResoursesTypesAndQuantities)
            {
                string resourse = kvp.Key;
                Dictionary<string, long> typesAndCounts = kvp.Value
                    .OrderByDescending(x => x.Key)
                    .ThenBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                bool hasToPrint = typesAndCounts.Any();
                if (hasToPrint)
                {
                    Console.WriteLine($"<{resourse}> ${typesAndCounts.Values.Sum()}");
                    Console.WriteLine(string.Join(Environment.NewLine, typesAndCounts
                        .Select(x => $"##{x.Key} - {x.Value}")));
                }
            }
        }
    }
}
