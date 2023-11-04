using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbolsAndCounts = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char currentSymbol in text)
            {
                bool isAdded = symbolsAndCounts.ContainsKey(currentSymbol);
                if (!isAdded)
                {
                    symbolsAndCounts.Add(currentSymbol, 0);
                }

                symbolsAndCounts[currentSymbol]++;
            }

            bool areAny = symbolsAndCounts.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, symbolsAndCounts
                    .Select(x => $"{x.Key}: {x.Value} time/s")));
            }
        }
    }
}
