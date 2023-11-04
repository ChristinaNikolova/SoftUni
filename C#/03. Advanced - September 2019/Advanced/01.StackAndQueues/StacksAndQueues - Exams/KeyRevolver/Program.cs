using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalMoney = int.Parse(Console.ReadLine());

            int counterShoots = 0;

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                counterShoots++;

                bool isBrokenLock = currentBullet <= currentLock;
                if (isBrokenLock)
                {
                    Console.WriteLine("Bang!");

                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bool hasToReload = counterShoots % sizeBarrel == 0;
                if (hasToReload && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            bool isSuccess = locks.Count == 0;
            if (isSuccess)
            {
                int earnedMoney = totalMoney - counterShoots * pricePerBullet;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
