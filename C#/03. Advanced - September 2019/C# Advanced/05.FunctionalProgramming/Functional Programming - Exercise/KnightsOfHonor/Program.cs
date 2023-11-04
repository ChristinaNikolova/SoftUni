using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> print = x => Console.WriteLine($"Sir {x}");

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
