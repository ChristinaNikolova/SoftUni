using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            for (int i = 0; i < firstNumber; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < secondNumber; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }

            HashSet<int> finalNumbers = firstSet
                .Intersect(secondSet)
                .ToHashSet();

            bool areAny = finalNumbers.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", finalNumbers));
            }
        }
    }
}
