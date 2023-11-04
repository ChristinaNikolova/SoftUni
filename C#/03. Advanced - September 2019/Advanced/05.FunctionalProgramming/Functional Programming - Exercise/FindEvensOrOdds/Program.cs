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

            int start = Math.Min(firstNumber, secondNumber);
            int end = Math.Max(firstNumber, secondNumber);
            string typeNumber = Console.ReadLine();

            Func<int, bool> filter = GetTheFilter(typeNumber);

            for (int currentNumber = start; currentNumber <= end; currentNumber++)
            {
                if (filter(currentNumber))
                {
                    Console.Write(currentNumber+" ");
                }
            }

            Console.WriteLine();
        }

        private static Func<int, bool> GetTheFilter(string typeNumber)
        {
            if (typeNumber == "even")
            {
                return x => x % 2 == 0;
            }
            else if (typeNumber == "odd")
            {
                return x => x % 2 == 1
                || x % 2 == -1;
            }
            else
            {
                return null;
            }
        }
    }
}
