using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] specialNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countToAdd = specialNumbers[0];
            int countToRemove = specialNumbers[1];
            int searchedNumber = specialNumbers[2];

            int[] numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            Stack<int> stack = new Stack<int>();

            int count = Math.Min(countToAdd, numbers.Length);

            for (int i = 0; i < count; i++)
            {
                int numberToAdd = numbers[i];

                stack.Push(numberToAdd);
            }

            for (int i = 0; i < countToRemove; i++)
            {
                bool isNumber = stack.Any();
                if (!isNumber)
                {
                    break;
                }

                stack.Pop();
            }

            bool isEmpty = stack.Count == 0;
            if (isEmpty)
            {
                Console.WriteLine("0");
            }
            else
            {
                bool isFound = stack.Contains(searchedNumber);
                if (isFound)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minNumber = stack.Min();

                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
