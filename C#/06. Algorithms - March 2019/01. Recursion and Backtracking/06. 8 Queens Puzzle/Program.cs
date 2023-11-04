using System;
using System.Collections.Generic;
using System.Text;

namespace _06._8_Queens_Puzzle
{
    class Program
    {
        private const int Size = 8;
        private static int[,] board = new int[Size, Size];

        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        static void Main(string[] args)
        {
            int startRow = 0;

            Solve(startRow);
        }

        private static void Solve(int row)
        {
            if (row == Size)
            {
                PrintResult();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (CanMove(row, col))
                {
                    MarkBoard(row, col);
                    Solve(row + 1);
                    UnmarkBoard(row, col);
                }
            }
        }

        private static void UnmarkBoard(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
        }

        private static bool CanMove(int row, int col)
        {
            return !(attackedRows.Contains(row)
                || attackedCols.Contains(col)
                || attackedLeftDiagonals.Contains(col - row)
                || attackedRightDiagonals.Contains(col + row));
        }

        private static void MarkBoard(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
        }

        private static void PrintResult()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
