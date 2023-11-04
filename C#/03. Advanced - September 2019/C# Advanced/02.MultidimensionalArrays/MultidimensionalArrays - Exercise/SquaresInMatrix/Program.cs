using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixProps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] elementsCurrentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elementsCurrentRow[col];
                }
            }

            int counterMatrixes = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char firstSymbol = matrix[row, col];
                    char secondSymbol = matrix[row, col + 1];
                    char thirdSymbol = matrix[row + 1, col];
                    char fourthSymbol = matrix[row + 1, col + 1];

                    bool areEqual = firstSymbol == secondSymbol && secondSymbol == thirdSymbol && thirdSymbol == fourthSymbol;
                    if (areEqual)
                    {
                        counterMatrixes++;
                    }
                }
            }

            Console.WriteLine(counterMatrixes);
        }
    }
}
