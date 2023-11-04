using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAndAges = new Dictionary<string, int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = elements[0];
                int age = int.Parse(elements[1]);

                namesAndAges.Add(name, age);
            }

            string condition = Console.ReadLine();
            int targetAge = int.Parse(Console.ReadLine());
            string formatToPrint = Console.ReadLine();

            Func<int, bool> filter = GetTheFilter(condition, targetAge);

            Func<string, int, string> format = GetTheFormat(formatToPrint);

            List<string> finalCollection = namesAndAges
                .Where(x => filter(x.Value))
                .Select(x => format(x.Key, x.Value))
                .ToList();

            bool areAny = finalCollection.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, finalCollection));
            }
        }

        private static Func<string, int, string> GetTheFormat(string formatToPrint)
        {
            if (formatToPrint == "name")
            {
                return (x, y) => $"{x}";
            }
            else if (formatToPrint == "age")
            {
                return (x, y) => $"{y}";
            }
            else if (formatToPrint == "name age")
            {
                return (x, y) => $"{x} - {y}";
            }
            else
            {
                return null;
            }
        }

        private static Func<int, bool> GetTheFilter(string condition, int targetAge)
        {
            if (condition == "younger")
            {
                return x => x < targetAge;
            }
            else if (condition == "older")
            {
                return x => x >= targetAge;
            }
            else
            {
                return null;
            }
        }
    }
}
