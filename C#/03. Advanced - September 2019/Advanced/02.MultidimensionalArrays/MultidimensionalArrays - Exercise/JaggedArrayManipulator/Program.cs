using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            decimal[][] matrixJagged = new decimal[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrixJagged[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                bool areEqual = matrixJagged[row].Length == matrixJagged[row + 1].Length;
                if (areEqual)
                {
                    for (int currentRow = row; currentRow < row + 2; currentRow++)
                    {
                        matrixJagged[currentRow] = matrixJagged[currentRow]
                            .Select(x => x * 2)
                            .ToArray();
                    }
                }
                else
                {
                    for (int currentRow = row; currentRow < row + 2; currentRow++)
                    {
                        matrixJagged[currentRow] = matrixJagged[currentRow]
                            .Select(x => x / 2)
                            .ToArray();
                    }
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);
                int value = int.Parse(elements[3]);

                bool areValid = row >= 0 && row <= rows - 1
                    && col >= 0 && col <= matrixJagged[row].Length - 1;
                if (!areValid)
                {
                    continue;
                }

                if(command== "Add")
                {
                    matrixJagged[row][col] += value;
                }
                else if(command== "Subtract")
                {
                    matrixJagged[row][col] -= value;
                }
            }

            foreach (decimal[] row in matrixJagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
