using System;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Lake lake = new Lake(numbers);

            if (lake.Any())
            {
                Console.WriteLine(string.Join(", ", lake));
            }
        }
    }
}
