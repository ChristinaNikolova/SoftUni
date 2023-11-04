using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            Queue<int> queue = new Queue<int>();

            int count = Math.Min(countToAdd, numbers.Length);

            for (int i = 0; i < count; i++)
            {
                int numberToAdd = numbers[i];

                queue.Enqueue(numberToAdd);
            }

            for (int i = 0; i < countToRemove; i++)
            {
                bool isNumber = queue.Any();
                if (!isNumber)
                {
                    break;
                }

                queue.Dequeue();
            }

            bool isEmpty = queue.Count == 0;
            if (isEmpty)
            {
                Console.WriteLine("0");
            }
            else
            {
                bool isFound = queue.Contains(searchedNumber);
                if (isFound)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minNumber = queue.Min();

                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
