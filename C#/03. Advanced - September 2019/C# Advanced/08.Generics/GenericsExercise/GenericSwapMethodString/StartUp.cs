using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentElement = Console.ReadLine();
                elements.Add(currentElement);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(elements, firstIndex, secondIndex);

            foreach (string element in elements)
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
