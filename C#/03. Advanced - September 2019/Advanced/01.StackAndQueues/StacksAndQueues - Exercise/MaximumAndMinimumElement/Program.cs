using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int commandNumber = elements[0];

                bool isNumber = numbers.Any();

                if (commandNumber == 1)
                {
                    int numberToAdd = elements[1];
                    numbers.Push(numberToAdd);
                }
                else if (commandNumber == 2)
                {
                    if (isNumber)
                    {
                        numbers.Pop();
                    }
                }
                else if (commandNumber == 3)
                {
                    if (isNumber)
                    {
                        int maxNumber = numbers.Max();
                        Console.WriteLine(maxNumber);
                    }
                }
                else if (commandNumber == 4)
                {
                    if (isNumber)
                    {
                        int minNumber = numbers.Min();
                        Console.WriteLine(minNumber);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
