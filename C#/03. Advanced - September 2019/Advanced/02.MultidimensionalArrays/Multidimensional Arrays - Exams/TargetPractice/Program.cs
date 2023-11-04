using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixProps = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            char[][] startMatrix = new char[rows][];

            string snake = Console.ReadLine();

            int counterIndexes = 0;

            for (int row = 0; row < rows; row++)
            {
                startMatrix[row] = new char[cols];

                for (int col = 0; col < cols; col++)
                {
                    startMatrix[row][col] = snake[counterIndexes];
                    counterIndexes++;

                    bool hasToReset = counterIndexes == snake.Length;
                    if (hasToReset)
                    {
                        counterIndexes = 0;
                    }
                }

                bool isEven = row % 2 == 0;
                if (isEven)
                {
                    startMatrix[row] = startMatrix[row]
                        .Reverse()
                        .ToArray();
                }
            }

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = startMatrix[rows - 1 - row];
            }

            int[] bombProps = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = bombProps[0];
            int targetCol = bombProps[1];
            int radius = bombProps[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isInRadius = Math.Pow(targetRow - row, 2) + Math.Pow(targetCol - col, 2) <= Math.Pow(radius, 2);
                    if (isInRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int counterEmptySpaces = 0;
                Queue<char> symbols = new Queue<char>();

                for (int row = 0; row < rows; row++)
                {
                    bool isEmpty = matrix[row][col] == ' ';
                    if (isEmpty)
                    {
                        counterEmptySpaces++;
                    }
                    else
                    {
                        symbols.Enqueue(matrix[row][col]);
                    }
                }

                for (int row = 0; row < counterEmptySpaces; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counterEmptySpaces; row < rows; row++)
                {
                    matrix[row][col] = symbols.Dequeue();
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
