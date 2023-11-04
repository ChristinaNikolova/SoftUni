using System;
using System.Linq;

namespace _01._Permutations_without_Repetition
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
            char[] permutation = new char[elements.Length];
            bool[] used = new bool[elements.Length];

            Permute(index, elements, permutation, used);
        }

        private static void Permute(int index, char[] elements, char[] permutation, bool[] used)
        {
            if (index == permutation.Length)
            {
                Console.WriteLine(string.Join(' ', permutation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[index] = elements[i];
                    Permute(index + 1, elements, permutation, used);
                    used[i] = false;
                }
            }
        }
    }
}
