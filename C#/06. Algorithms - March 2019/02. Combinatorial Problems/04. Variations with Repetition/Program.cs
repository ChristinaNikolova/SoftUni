using System;
using System.Linq;

namespace _04._Variations_with_Repetition
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

            int index = 0;
            char[] variation = new char[count];

            Variate(index, variation, elements);
        }

        private static void Variate(int index, char[] variation, char[] elements)
        {
            if (index == variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variation[index] = elements[i];
                Variate(index + 1, variation, elements);
            }
        }
    }
}
