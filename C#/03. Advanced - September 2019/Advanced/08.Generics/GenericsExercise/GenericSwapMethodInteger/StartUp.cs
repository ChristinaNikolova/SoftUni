using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> elements = new List<int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                elements.Add(currentNumber);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(elements, firstIndex, secondIndex);

            foreach (int element in elements)
            {
                Console.WriteLine($"{element.GetType()}: {element}");
            }
        }

        public static void Swap<T>(List<T> elements, int firstIndex, int secondIndex)
        {
            T firstElement = elements[firstIndex];
            T secondElement = elements[secondIndex];

            elements[firstIndex] = secondElement;
            elements[secondIndex] = firstElement;
        }
    }
}
