using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = names
                .Where(x => x.ToCharArray().Sum(y => y) >= targetSum)
                .FirstOrDefault();

            Console.WriteLine(name);
        }
    }
}