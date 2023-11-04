using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Sum_of_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int targetSum = int.Parse(Console.ReadLine());

            int totalCointsCounter = 0;
            StringBuilder sb = new StringBuilder();

            List<int> sortedCoins = coins
                .OrderByDescending(x => x)
                .ToList();

            while (targetSum > 0 && sortedCoins.Count > 0)
            {
                int currentCoinValue = sortedCoins[0];
                sortedCoins.RemoveAt(0);

                if (targetSum < currentCoinValue)
                {
                    continue;
                }

                int currentCoinsCount = targetSum / currentCoinValue;
                totalCointsCounter += currentCoinsCount;
                targetSum -= currentCoinsCount * currentCoinValue;
                sb.AppendLine($"{currentCoinsCount} coin(s) with value {currentCoinValue}");
            }

            if (targetSum > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {totalCointsCounter}");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
