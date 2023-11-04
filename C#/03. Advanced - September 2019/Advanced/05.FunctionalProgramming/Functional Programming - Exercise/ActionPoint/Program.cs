using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> print = x => Console.WriteLine(x);

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
