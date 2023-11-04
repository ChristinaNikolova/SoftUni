using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] matrixProps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            int[,] matrix = new int[rows, cols];

            GetTheValuesOfTheMatrix(rows, cols, matrix);

            string input = string.Empty;

            long totalSumStarsPower = 0;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoProps = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilProps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilProps[0];
                int evilCol = evilProps[1];

                EvilMoves(matrix, ref evilRow, ref evilCol);

                int ivoRow = ivoProps[0];
                int ivoCol = ivoProps[1];

                IvoMove(matrix, ref totalSumStarsPower, ref ivoRow, ref ivoCol);
            }

            Console.WriteLine(totalSumStarsPower);

        }

        private static void IvoMove(int[,] matrix, ref long totalSumStarsPower, ref int ivoRow, ref int ivoCol)
        {
            while (ivoRow >= 0)
            {
                if (IsInMatrix(matrix,ivoRow, ivoCol))
                {
                    totalSumStarsPower += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private static void EvilMoves(int[,] matrix, ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0)
            {
                if (IsInMatrix(matrix, evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static bool IsInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static void GetTheValuesOfTheMatrix(int rows, int cols, int[,] matrix)
        {
            int counterStars = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = counterStars;
                    counterStars++;
                }
            }
        }
    }
}
