using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countNumbers = numbers.Count();
            int sumNumbers = numbers.Sum();

            Console.WriteLine(countNumbers);
            Console.WriteLine(sumNumbers);
        }
    }
}
