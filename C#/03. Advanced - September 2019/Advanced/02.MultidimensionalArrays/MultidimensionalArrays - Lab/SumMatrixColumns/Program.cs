using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixProps = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elementsCurrentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elementsCurrentRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sumElementsCurrentCol = 0;

                for (int row = 0; row < rows; row++)
                {
                    sumElementsCurrentCol += matrix[row, col];
                }

                Console.WriteLine(sumElementsCurrentCol);
            }
        }
    }
}
