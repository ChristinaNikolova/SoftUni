using System;
using System.Linq;

namespace _05._Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int count = int.Parse(Console.ReadLine());

            int[] combination = new int[count];
            int index = 0;
            int border = -1;

            GenerateCombination(index, border, combination, numbers);
        }

        private static void GenerateCombination(int index, int border, int[] combination, int[] numbers)
        {
            if (index == combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = border + 1; i < numbers.Length; i++)
            {
                combination[index] = numbers[i];
                GenerateCombination(index + 1, i, combination, numbers);
            }
        }
    }
}
