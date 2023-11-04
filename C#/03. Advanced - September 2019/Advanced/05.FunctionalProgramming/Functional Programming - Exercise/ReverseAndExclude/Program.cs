using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> filter = CheckTheDivider(divider);

            numbers = numbers
                .Where(x => filter(x))
                .ToArray();

            bool areAny = numbers.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static Func<int, bool> CheckTheDivider(int divider)
        {
            return x => x % divider != 0;
        }
    }
}
