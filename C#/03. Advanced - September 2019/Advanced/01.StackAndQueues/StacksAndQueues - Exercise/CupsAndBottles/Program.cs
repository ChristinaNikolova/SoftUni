using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> bottles = new Stack<int>(Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse));

            int totalWastedWater = 0;

            while (bottles.Any() && cups.Any())
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups[0];

                cups.RemoveAt(0);

                bool isWaterEnough = currentCup <= currentBottle;
                if (isWaterEnough)
                {
                    currentBottle -= currentCup;
                    totalWastedWater += currentBottle;
                }
                else
                {
                    currentCup -= currentBottle;
                    cups.Insert(0, currentCup);
                }
            }

            bool isSuccess = cups.Count == 0;
            if (!isSuccess)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
        }
    }
}
