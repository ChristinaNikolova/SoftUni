using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int rackCapacity = int.Parse(Console.ReadLine());

            int counterRacks = 1;
            int leftCapacity = rackCapacity;

            while (clothes.Any())
            {
                int currentPieceOfCloth = clothes.Peek();

                bool isSpaceEnough = currentPieceOfCloth <= leftCapacity;
                if (!isSpaceEnough)
                {
                    leftCapacity = rackCapacity;
                    counterRacks++;

                    continue;
                }

                leftCapacity -= currentPieceOfCloth;
                clothes.Pop();
            }

            Console.WriteLine(counterRacks);
        }
    }
}
