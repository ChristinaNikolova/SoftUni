using System;
using System.Linq;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = 8;

            char[][] matrix = new char[sizeMatrix][];

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                char figure = elements[0][0];
                int currentRow = int.Parse((elements[0][1]).ToString());
                int currentCol = int.Parse((elements[0][2]).ToString());

                int targetRow = int.Parse((elements[1][0]).ToString());
                int targetCol = int.Parse((elements[1][1]).ToString());

                bool isSuchFigure = CheckIfTheFigureIsValid(figure, currentRow, currentCol, matrix, sizeMatrix);
                if (!isSuchFigure)
                {
                    Console.WriteLine($"There is no such a piece!");
                    continue;
                }

                bool isMoveValid = CheckIfTheMoveIsValid(currentRow, currentCol, targetRow, targetCol, figure);
                if (!isMoveValid)
                {
                    Console.WriteLine($"Invalid move!");
                    continue;
                }

                bool isNewPositionInMatrix = CheckIfTheNewPositionIsInMatrix(targetRow, targetCol, sizeMatrix);
                if (!isNewPositionInMatrix)
                {
                    Console.WriteLine($"Move go out of board!");
                    continue;
                }

                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
        }

        private static bool CheckIfTheNewPositionIsInMatrix(int targetRow, int targetCol, int sizeMatrix)
        {
            return targetRow >= 0 && targetRow <= sizeMatrix - 1
                && targetCol >= 0 && targetCol <= sizeMatrix - 1;
        }

        private static bool CheckIfTheMoveIsValid(int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            if (figure == 'P')
            {
                return MovePawn(currentRow, currentCol, targetRow, targetCol);
            }
            else if (figure == 'R')
            {
                return MoveRook(currentRow, currentCol, targetRow, targetCol);
            }
            else if (figure == 'B')
            {
                return MoveBishof(currentRow, currentCol, targetRow, targetCol);
            }
            else if (figure == 'Q')
            {
                return MoveBishof(currentRow, currentCol, targetRow, targetCol)
                    || MoveRook(currentRow, currentCol, targetRow, targetCol);
            }
            else if (figure == 'K')
            {
                return MoveKing(currentRow, currentCol, targetRow, targetCol);
            }
            else
            {
                return false;
            }
        }

        private static bool MoveKing(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            bool moveRow = currentRow == targetRow && Math.Abs(currentCol - targetCol) == 1;
            bool moveCol = currentCol == targetCol && Math.Abs(currentRow - targetRow) == 1;
            bool moveDiagonal = Math.Abs(currentCol - targetCol) == 1 && Math.Abs(currentRow - targetRow) == 1;

            return moveRow
                || moveCol
                || moveDiagonal;
        }

        private static bool MoveBishof(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            return Math.Abs(currentRow - targetRow) == Math.Abs(currentCol - targetCol);
        }

        private static bool MoveRook(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            return currentRow == targetRow
                || currentCol == targetCol;
        }

        private static bool MovePawn(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            return currentCol == targetCol && currentRow - 1 == targetRow;
        }

        private static bool CheckIfTheFigureIsValid(char figure, int currentRow, int currentCol, char[][] matrix, int sizeMatrix)
        {
            return currentRow >= 0 && currentRow <= sizeMatrix - 1
                && currentCol >= 0 && currentCol <= sizeMatrix - 1
                && matrix[currentRow][currentCol] == figure;
        }
    }
}
