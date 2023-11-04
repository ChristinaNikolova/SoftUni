using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pairs = new List<int>();

            Stack<int> leftSocks = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            Queue<int> rightSocks = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentLeft = leftSocks.Pop();
                int currentRight = rightSocks.Peek();

                if (currentLeft > currentRight)
                {
                    int pair = currentLeft + currentRight;
                    pairs.Add(pair);

                    rightSocks.Dequeue();
                }
                else if (currentLeft < currentRight)
                {
                    continue;
                }
                else
                {
                    rightSocks.Dequeue();

                    currentLeft += 1;
                    leftSocks.Push(currentLeft);
                }
            }

            int maxPair = pairs.Max();

            Console.WriteLine(maxPair);
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
