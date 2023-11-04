using System;
using System.Linq;

namespace BunkerBuster
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

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "cease fire!")
            {
                string[] elements = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int targetRow = int.Parse(elements[0]);
                int targetCol = int.Parse(elements[1]);
                char powerSymbol = char.Parse(elements[2]);

                int fullPower = powerSymbol;
                int halfPower = (int)Math.Ceiling(powerSymbol / 2.0);

                matrix[targetRow][targetCol] -= fullPower;

                if (IsInMatrix(targetRow - 1, targetCol - 1, rows, cols))
                {
                    matrix[targetRow - 1][targetCol - 1] -= halfPower;
                }

                if (IsInMatrix(targetRow - 1, targetCol, rows, cols))
                {
                    matrix[targetRow - 1][targetCol] -= halfPower;
                }

                if (IsInMatrix(targetRow - 1, targetCol + 1, rows, cols))
                {
                    matrix[targetRow - 1][targetCol + 1] -= halfPower;
                }

                if (IsInMatrix(targetRow, targetCol - 1, rows, cols))
                {
                    matrix[targetRow][targetCol - 1] -= halfPower;
                }

                if (IsInMatrix(targetRow, targetCol + 1, rows, cols))
                {
                    matrix[targetRow][targetCol + 1] -= halfPower;
                }

                if (IsInMatrix(targetRow + 1, targetCol - 1, rows, cols))
                {
                    matrix[targetRow + 1][targetCol - 1] -= halfPower;
                }

                if (IsInMatrix(targetRow + 1, targetCol, rows, cols))
                {
                    matrix[targetRow + 1][targetCol] -= halfPower;
                }

                if (IsInMatrix(targetRow + 1, targetCol + 1, rows, cols))
                {
                    matrix[targetRow + 1][targetCol + 1] -= halfPower;
                }
            }

            int counterDeadCells = 0;

            foreach (int[] row in matrix)
            {
                counterDeadCells += row
                    .Where(x => x <= 0)
                    .Count();
            }

            int totalCells = rows * cols;

            double percent = (1.0 * counterDeadCells / totalCells) * 100;
            double finalPercent = Math.Round(percent, 1, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Destroyed bunkers: {counterDeadCells}");
            Console.WriteLine($"Damage done: {finalPercent:F1} %");
        }

        private static bool IsInMatrix(int targetRow, int targetCol, int rows, int cols)
        {
            return targetRow >= 0 && targetRow <= rows - 1
                && targetCol >= 0 && targetCol <= cols - 1;
        }
    }
}
