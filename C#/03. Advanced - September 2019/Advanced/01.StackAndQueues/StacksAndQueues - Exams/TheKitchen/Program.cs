using System;
using System.Collections.Generic;
using System.Linq;

namespace TheKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();

            Stack<int> knives = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> forks = new Queue<int>(Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse));

            while (knives.Any() && forks.Any())
            {
                int currentKnife = knives.Pop();
                int currentFork = forks.Peek();

                if (currentKnife > currentFork)
                {
                    int set = currentKnife + currentFork;
                    sets.Add(set);

                    forks.Dequeue();
                }
                else if (currentKnife < currentFork)
                {
                    continue;
                }
                else
                {
                    forks.Dequeue();

                    currentKnife += 1;
                    knives.Push(currentKnife);
                }
            }

            int maxSet = sets.Max();

            Console.WriteLine($"The biggest set is: {maxSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
