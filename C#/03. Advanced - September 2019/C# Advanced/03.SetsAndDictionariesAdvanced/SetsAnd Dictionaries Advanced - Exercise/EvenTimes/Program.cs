using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersAndCounts = new Dictionary<int, int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                bool isNumberAdded = numbersAndCounts.ContainsKey(currentNumber);
                if (!isNumberAdded)
                {
                    numbersAndCounts.Add(currentNumber, 0);
                }

                numbersAndCounts[currentNumber]++;
            }

            int searchedNumber = numbersAndCounts
                .Where(x => x.Value % 2 == 0)
                .FirstOrDefault()
                .Key;

            Console.WriteLine(searchedNumber);
        }
    }
}
