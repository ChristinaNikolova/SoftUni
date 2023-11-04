using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string element in elements)
                {
                    uniqueElements.Add(element);
                }
            }

            bool areAny = uniqueElements.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", uniqueElements));
            }
        }
    }
}
