using System;
using System.Collections.Generic;

namespace _07._Paths_in_Labyrinth
{
    class Program
    {
        private static char[,] matrix;
        private static List<char> path = new List<char>();
        static void Main(string[] args)
        {
            ReadInput();

            int startRow = 0;
            int startCol = 0;
            char startDirection = 'S';

            Solve(startRow, startCol, startDirection);
        }

        private static void Solve(int row, int col, char direction)
        {
            if (IsOutsideMatrix(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintResult();
            }
            else if (CanMove(row, col))
            {
                MarkMatrix(row, col);
                Solve(row + 1, col, 'D');
                Solve(row - 1, col, 'U');
                Solve(row, col + 1, 'R');
                Solve(row, col - 1, 'L');
                UnmarkMatrix(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void UnmarkMatrix(int row, int col)
        {
            matrix[row, col] = '-';
        }

        private static void MarkMatrix(int row, int col)
        {
            matrix[row, col] = 'x';
        }

        private static bool CanMove(int row, int col)
        {
            return matrix[row, col] == '-';
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(string.Empty, path).TrimStart('S'));
        }

        private static bool IsExit(int row, int col)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsOutsideMatrix(int row, int col)
        {
            return row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1);
        }

        private static void ReadInput()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRowInput = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRowInput[col];
                }
            }
        }
    }
}
