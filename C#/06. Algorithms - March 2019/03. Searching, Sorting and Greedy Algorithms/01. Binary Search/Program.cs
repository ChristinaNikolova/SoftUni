using System;
using System.Linq;

namespace _01._Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int searchedNumber = int.Parse(Console.ReadLine());

            int startIndex = 0;
            int endIndex = numbers.Length - 1;

            int index = BinarySearch(numbers, searchedNumber, startIndex, endIndex);

            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] numbers, int searchedNumber, int startIndex, int endIndex)
        {
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (numbers[midIndex] == searchedNumber)
                {
                    return midIndex;
                }

                if (numbers[midIndex] > searchedNumber)
                {
                    endIndex = midIndex - 1;
                }

                if (numbers[midIndex] < searchedNumber)
                {
                    startIndex = midIndex + 1;
                }
            }

            return -1;
        }
    }
}
