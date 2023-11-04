using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorsClothsCount = new Dictionary<string, Dictionary<string, int>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = elements[0];

                string[] cloths = elements[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isColorAdded = colorsClothsCount.ContainsKey(color);
                if (!isColorAdded)
                {
                    colorsClothsCount.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothing in cloths)
                {
                    bool isAdded = colorsClothsCount[color].ContainsKey(clothing);
                    if (!isAdded)
                    {
                        colorsClothsCount[color].Add(clothing, 0);
                    }

                    colorsClothsCount[color][clothing]++;
                }
            }

            string[] searchedElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string searchedColor = searchedElements[0];
            string searchedClothing = searchedElements[1];

            foreach (var (color, clothsAndCounts) in colorsClothsCount)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (clothing, count) in clothsAndCounts)
                {
                    bool isFound = color == searchedColor && clothing == searchedClothing;
                    if (isFound)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {clothing} - {count}");
                }
            }
        }
    }
}
