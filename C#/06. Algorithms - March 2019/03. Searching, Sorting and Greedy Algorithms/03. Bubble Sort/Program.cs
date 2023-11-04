using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                int counter = 0;

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(numbers, i);
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    isSorted = true;
                }
            }
        }

        private static void Swap(int[] numbers, int i)
        {
            int temp = numbers[i];
            numbers[i] = numbers[i + 1];
            numbers[i + 1] = temp;
        }
    }
}
