using System;
using System.Linq;

namespace _03._Variations_without_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] elements = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            int count = int.Parse(Console.ReadLine());

            char[] variation = new char[count];
            bool[] used = new bool[elements.Length];
            int index = 0;

            Variate(index, elements, variation, used);
        }

        private static void Variate(int index, char[] elements, char[] variation, bool[] used)
        {
            if (index == variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variation[index] = elements[i];
                    Variate(index + 1, elements, variation, used);
                    used[i] = false;
                }
            }
        }
    }
}
