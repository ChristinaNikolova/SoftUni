using System;
using System.Linq;

namespace _02._Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            SelectionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                int counter = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i; j < numbers.Length; j++)
                    {
                        if (numbers[i] > numbers[j])
                        {
                            Swap(numbers, i, j);
                            counter++;
                        }
                    }
                }

                if (counter == 0)
                {
                    isSorted = true;
                }
            }
        }

        private static void Swap(int[] numbers, int i, int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
