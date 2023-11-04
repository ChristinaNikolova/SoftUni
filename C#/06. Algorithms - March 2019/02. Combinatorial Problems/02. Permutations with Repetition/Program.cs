using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Permutations_with_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] elements = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            int index = 0;
            int start = 0;

            Permute(index, start, elements);
        }

        private static void Permute(int index, int start, char[] elements)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            HashSet<int> used = new HashSet<int>();

            for (int i = start; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(index, i, elements);
                    Permute(index + 1, start + 1, elements);
                    Swap(index, i, elements);
                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int index, int i, char[] elements)
        {
            char temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
