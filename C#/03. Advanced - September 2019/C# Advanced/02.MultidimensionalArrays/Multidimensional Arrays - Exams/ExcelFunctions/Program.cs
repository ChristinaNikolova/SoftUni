using System;
using System.Linq;

namespace ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = elements[0];
            string header = elements[1];

            int indexHeader = Array.IndexOf(matrix[0], header);

            if (command == "hide")
            {
                var secondMatrix = matrix
                    .Select(x => x.Where((y, i) => i != indexHeader))
                    .ToArray();

                foreach (var row in secondMatrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            else if (command == "sort")
            {
                Console.WriteLine(string.Join(" | ", matrix[0]));

                string[][] secondMatrix = new string[rows - 1][];

                for (int row = 0; row < rows - 1; row++)
                {
                    secondMatrix[row] = matrix[row + 1];
                }

                secondMatrix = secondMatrix
                    .OrderBy(x => x[indexHeader])
                    .ToArray();

                foreach (var row in secondMatrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            if (command == "filter")
            {
                string value = elements[2];

                Console.WriteLine(string.Join(" | ", matrix[0]));

                matrix = matrix
                    .Where(x => x[indexHeader] == value)
                    .ToArray();

                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
