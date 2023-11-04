using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> filter = GetTheNames(maxLenght);

            names = names
                .Where(x => filter(x))
                .ToArray();

            bool areAny = names.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }

        }

        private static Func<string, bool> GetTheNames(int maxLenght)
        {
            return x => x.Length <= maxLenght;
        }
    }
}
