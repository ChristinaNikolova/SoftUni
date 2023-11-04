using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, endNumber)
                .ToList();

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int number in numbers)
            {
                bool isValid = true;

                foreach (int divider in dividers)
                {
                    if (number % divider != 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }
    }
}