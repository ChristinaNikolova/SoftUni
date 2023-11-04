using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> evenNumbers = numbers
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            List<int> oddNumbers = numbers
                .Where(x => x % 2 != 0)
                .OrderBy(x => x)
                .ToList();

            evenNumbers.AddRange(oddNumbers);

            bool areAny = evenNumbers.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
        }
    }
}
