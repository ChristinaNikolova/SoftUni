using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> evenNumbers = new Queue<int>();

            while (numbers.Any())
            {
                int currentNumber = numbers.Dequeue();

                bool isEven = currentNumber % 2 == 0;
                if (!isEven)
                {
                    continue;
                }

                evenNumbers.Enqueue(currentNumber);
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
