using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersAndCounts = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToArray();

            foreach (double number in numbers)
            {
                bool isAdded = numbersAndCounts.ContainsKey(number);
                if (!isAdded)
                {
                    numbersAndCounts.Add(number, 0);
                }

                numbersAndCounts[number]++;
            }

            bool areAny = numbersAndCounts.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, numbersAndCounts
                    .Select(x => $"{x.Key} - {x.Value} times")));
            }
        }
    }
}
