using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> diffrences = new Queue<int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int amountPetrol = elements[0];
                int distanceToTravel = elements[1];

                int diff = amountPetrol - distanceToTravel;
                diffrences.Enqueue(diff);
            }

            bool hasToBreak = false;
            int minIndex = 0;

            while (!hasToBreak)
            {
                int totalPetrol = 0;

                foreach (int currentDiff in diffrences)
                {
                    totalPetrol += currentDiff;

                    bool isEnough = totalPetrol >= 0;
                    if (!isEnough)
                    {
                        int diffToMoveBack = diffrences.Dequeue();
                        diffrences.Enqueue(diffToMoveBack);

                        break;
                    }
                }

                bool isSuccess = totalPetrol >= 0;
                if (!isSuccess)
                {
                    minIndex++;
                }
                else
                {
                    hasToBreak = true;
                }
            }

            Console.WriteLine(minIndex);
        }
    }
}
