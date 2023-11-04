using System;
using System.Linq;

namespace _06._Combinations_with_Repetition
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

            char[] combination = new char[count];
            int index = 0;
            int start = 0;

            Combinate(index, start, elements, combination);
        }

        private static void Combinate(int index, int start, char[] elements, char[] combination)
        {
            if (index == combination.Length)
            {
                Console.WriteLine(string.Join(' ', combination));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[index] = elements[i];
                Combinate(index + 1, i, elements, combination);
            }
        }
    }
}
