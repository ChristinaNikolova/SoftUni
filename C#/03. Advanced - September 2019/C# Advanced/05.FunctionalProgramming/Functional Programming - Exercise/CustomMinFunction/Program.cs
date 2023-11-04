using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            int startNumber = Math.Min(firstNumber, secondNumber);
            int endNumber = Math.Max(firstNumber, secondNumber);

            List<int> collectionNumbers = Enumerable.Range(startNumber, endNumber - startNumber + 1)
                .ToList();

            string typeNumber = Console.ReadLine();

            Predicate<int> filter = GetTheFilter(typeNumber);

            collectionNumbers = collectionNumbers
                .FindAll(x => filter(x))
                .ToList();

            bool areAny = collectionNumbers.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", collectionNumbers));
            }
        }

        private static Predicate<int> GetTheFilter(string typeNumber)
        {
            if (typeNumber == "even")
            {
                return x => x % 2 == 0;
            }
            else if (typeNumber == "odd")
            {
                return x => x % 2 != 0;
            }
            else
            {
                return null;
            }
        }
    }
}