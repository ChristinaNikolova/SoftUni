using System;
using System.Linq;

namespace MatrixShuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] elementsCurrentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elementsCurrentRow[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                bool containsSwap = input.StartsWith("swap");
                if (!containsSwap)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isLenghtValid = elements.Length == 5;
                if (!isLenghtValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRow = int.Parse(elements[1]);
                int firstCol = int.Parse(elements[2]);
                int secondRow = int.Parse(elements[3]);
                int secondCol = int.Parse(elements[4]);

                bool isFirstRowValid = IsInMatrix(firstRow, rows);
                bool isFirstColValid = IsInMatrix(firstCol, cols);
                bool isSecondRowValid = IsInMatrix(secondRow, rows);
                bool isSecondColValid = IsInMatrix(secondCol, cols);

                bool areAllValid = isFirstRowValid && isFirstColValid && isSecondRowValid && isSecondColValid;
                if (!areAllValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstElement = matrix[firstRow, firstCol];
                string secondElement = matrix[secondRow, secondCol];

                matrix[firstRow, firstCol] = secondElement;
                matrix[secondRow, secondCol] = firstElement;

                PrintTheMatrix(matrix);
            }
        }

        private static void PrintTheMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInMatrix(int element, int elements)
        {
            bool isValid = element >= 0 && element <= elements - 1;

            return isValid;
        }
    }
}
