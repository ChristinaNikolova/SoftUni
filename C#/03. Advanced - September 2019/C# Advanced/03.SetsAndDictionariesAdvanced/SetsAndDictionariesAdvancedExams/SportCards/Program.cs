using System;
using System.Collections.Generic;
using System.Linq;

namespace SportCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> cardsSportsAndPrices
                = new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input.Contains("-"))
                {
                    string[] elements = input
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string card = elements[0];
                    string sport = elements[1];
                    double price = double.Parse(elements[2]);

                    bool isCardAdded = cardsSportsAndPrices.ContainsKey(card);
                    if (!isCardAdded)
                    {
                        cardsSportsAndPrices.Add(card, new Dictionary<string, double>());
                    }

                    bool isSportAdded = cardsSportsAndPrices[card].ContainsKey(sport);
                    if (!isSportAdded)
                    {
                        cardsSportsAndPrices[card].Add(sport, 0);
                    }

                    cardsSportsAndPrices[card][sport] = price;
                }
                else
                {
                    string[] elements = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string card = elements[1];

                    bool isCardAdded = cardsSportsAndPrices.ContainsKey(card);
                    if (isCardAdded)
                    {
                        Console.WriteLine($"{card} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{card} is not available!");
                    }
                }
            }

            Dictionary<string, Dictionary<string, double>> sortedCardsSportsAndPrices = cardsSportsAndPrices
                .OrderByDescending(x => x.Value.Keys.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedCardsSportsAndPrices)
            {
                string card = kvp.Key;
                Dictionary<string, double> sportsAndPrices = kvp.Value
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{card}:");

                bool areAny = sportsAndPrices.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, sportsAndPrices
                        .Select(x=>$"  -{x.Key} - {x.Value:F2}")));
                }
            }
        }
    }
}
