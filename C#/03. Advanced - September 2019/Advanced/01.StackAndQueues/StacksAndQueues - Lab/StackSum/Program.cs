using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(elements[1]);
                    int secondNumber = int.Parse(elements[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(elements[1]);

                    bool areNumberEnough = count <= numbers.Count;
                    if (!areNumberEnough)
                    {
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        numbers.Pop();
                    }
                }
            }

            int sumNumbers = numbers.Sum();

            Console.WriteLine($"Sum: {sumNumbers}");
        }
    }
}
