using System;
using System.Linq;

namespace _06._Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] sortedNumbers = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sortedNumbers));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            int[] leftArray = numbers.Take(numbers.Length / 2).ToArray();
            int[] rigthArray = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(leftArray), MergeSort(rigthArray));
        }

        private static int[] Merge(int[] leftArray, int[] rigthArray)
        {
            int[] mergedArray = new int[leftArray.Length + rigthArray.Length];

            int mergedIndex = 0;
            int leftIndex = 0;
            int rigthIndex = 0;

            while (leftIndex <= leftArray.Length - 1 && rigthIndex <= rigthArray.Length - 1)
            {
                if (leftArray[leftIndex] < rigthArray[rigthIndex])
                {
                    mergedArray[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[mergedIndex] = rigthArray[rigthIndex];
                    rigthIndex++;
                }

                mergedIndex++;
            }

            while (leftIndex <= leftArray.Length - 1)
            {
                mergedArray[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rigthIndex <= rigthArray.Length - 1)
            {
                mergedArray[mergedIndex] = rigthArray[rigthIndex];
                rigthIndex++;
                mergedIndex++;
            }

            return mergedArray;
        }
    }
}
