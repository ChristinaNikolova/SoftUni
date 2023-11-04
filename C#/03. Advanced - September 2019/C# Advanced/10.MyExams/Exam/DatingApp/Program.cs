using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        private static object queue;

        static void Main(string[] args)
        {
            int counterMatches = 0;

            int[] malesInput = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> males = new Stack<int>(malesInput);

            int[] femalesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> females = new Queue<int>(femalesInput);

            while (females.Any() && males.Any())
            {
                int currentFemale = females.Peek();
                int currentMale = males.Peek();

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }

                if (currentFemale == currentMale)
                {
                    counterMatches++;
                    females.Dequeue();
                    males.Pop();
                }
                else
                {
                    females.Dequeue();
                    currentMale -= 2;

                    males.Pop();
                    males.Push(currentMale);
                }
            }

            Console.WriteLine($"Matches: {counterMatches}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
