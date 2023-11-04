using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x + x * 0.2)
                .ToArray();

            bool areAny = numbers.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, numbers
                    .Select(x => x.ToString("F2"))));
            }
        }
    }
}
