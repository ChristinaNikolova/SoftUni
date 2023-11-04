using System;
using System.Linq;

namespace _05._Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int startIndex = 0;
            int endIndex = numbers.Length - 1;

            Quicksort(numbers, startIndex, endIndex);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivot = startIndex;
            int leftIndex = startIndex + 1;
            int rigthIndex = endIndex;

            while (leftIndex <= rigthIndex)
            {
                if (numbers[leftIndex] > numbers[pivot] && numbers[rigthIndex] < numbers[pivot])
                {
                    Swap(numbers, leftIndex, rigthIndex);
                }

                if (numbers[leftIndex] <= numbers[pivot])
                {
                    leftIndex++;
                }

                if (numbers[rigthIndex] >= numbers[pivot])
                {
                    rigthIndex--;
                }
            }

            Swap(numbers, pivot, rigthIndex);

            bool isLeftSubArraySmaller = rigthIndex - 1 - startIndex < endIndex - rigthIndex + 1;

            if (isLeftSubArraySmaller)
            {
                Quicksort(numbers, startIndex, rigthIndex - 1);
                Quicksort(numbers, rigthIndex + 1, endIndex);
            }
            else
            {
                Quicksort(numbers, rigthIndex + 1, endIndex);
                Quicksort(numbers, startIndex, rigthIndex - 1);
            }
        }

        private static void Swap(int[] numbers, int leftIndex, int rigthIndex)
        {
            int temp = numbers[leftIndex];
            numbers[leftIndex] = numbers[rigthIndex];
            numbers[rigthIndex] = temp;
        }
    }
}
