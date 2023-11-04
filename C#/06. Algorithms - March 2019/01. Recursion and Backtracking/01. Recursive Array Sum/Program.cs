using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int index = 0;

            int sum = Sum(index, numbers);

            Console.WriteLine(sum);
        }

        private static int Sum(int index, int[] numbers)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            return numbers[index] + Sum(index + 1, numbers);
        }
    }
}
