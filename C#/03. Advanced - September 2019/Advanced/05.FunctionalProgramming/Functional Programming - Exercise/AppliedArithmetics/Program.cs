using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    bool areAny = numbers.Any();
                    if (areAny)
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    }

                    continue;
                }

                Func<int, int> format = GetTheNewValues(input);

                numbers = numbers
                    .Select(x => format(x))
                    .ToArray();
            }
        }

        private static Func<int, int> GetTheNewValues(string input)
        {
            if (input == "add")
            {
                return x => x + 1;
            }
            else if (input == "multiply")
            {
                return x => x * 2;
            }
            else if (input == "subtract")
            {
                return x => x - 1;
            }
            else
            {
                return null;
            }
        }
    }
}
