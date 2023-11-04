using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopsProductsPrices
                = new SortedDictionary<string, Dictionary<string, double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] elements = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shop = elements[0];
                string product = elements[1];
                double price = double.Parse(elements[2]);

                bool isShopAdded = shopsProductsPrices.ContainsKey(shop);
                if (!isShopAdded)
                {
                    shopsProductsPrices.Add(shop, new Dictionary<string, double>());
                }

                bool isProductAdded = shopsProductsPrices[shop].ContainsKey(product);
                if (!isProductAdded)
                {
                    shopsProductsPrices[shop].Add(product, price);
                }
            }

            foreach (var kvp in shopsProductsPrices)
            {
                string shop = kvp.Key;
                Dictionary<string, double> productsAndPrices = kvp.Value;

                Console.WriteLine($"{shop}->");

                bool areAny = productsAndPrices.Any();
                if (areAny)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, productsAndPrices
                        .Select(x => $"Product: {x.Key}, Price: {x.Value}")));
                }
            }
        }
    }
}
