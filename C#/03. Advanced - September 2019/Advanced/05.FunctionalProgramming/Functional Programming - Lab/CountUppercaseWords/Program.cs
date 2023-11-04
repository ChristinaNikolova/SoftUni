using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToArray();

            bool areAny = words.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, words));
            }
        }
    }
}
