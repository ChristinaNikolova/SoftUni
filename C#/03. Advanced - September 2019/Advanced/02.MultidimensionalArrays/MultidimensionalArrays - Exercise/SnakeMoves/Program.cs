using System;
using System.Linq;

namespace SnakeMoves
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

            string snake = Console.ReadLine();

            int counterIndexesSnake = 0;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = snake[counterIndexesSnake];

                    counterIndexesSnake++;

                    bool hasToChange = counterIndexesSnake == snake.Length;
                    if (hasToChange)
                    {
                        counterIndexesSnake = 0;
                    }
                }

                bool isOddRow = row % 2 == 1;
                if (isOddRow)
                {
                    matrix[row] = matrix[row]
                        .Reverse()
                        .ToArray();
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
