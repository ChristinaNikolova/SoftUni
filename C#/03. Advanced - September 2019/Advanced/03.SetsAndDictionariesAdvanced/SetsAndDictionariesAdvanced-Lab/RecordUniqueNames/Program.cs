using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentName = Console.ReadLine();
                uniqueNames.Add(currentName);
            }

            bool areAny = uniqueNames.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, uniqueNames));
            }
        }
    }
}
