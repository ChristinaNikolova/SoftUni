using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[][] matrix = new int[sizeMatrix][];

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] bombsProps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombsProps.Length; i++)
            {
                int[] elementsCurrentBomb = bombsProps[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int rowBomb = elementsCurrentBomb[0];
                int colBomb = elementsCurrentBomb[1];

                int valueBomb = matrix[rowBomb][colBomb];

                bool isBombAlive = valueBomb > 0;
                if (!isBombAlive)
                {
                    continue;
                }

                matrix[rowBomb][colBomb] = 0;

                GetTheNewValues(rowBomb, colBomb, sizeMatrix, valueBomb, matrix);
            }

            int counterAliveCells = 0;
            int sumAliveCells = 0;

            foreach (int[] row in matrix)
            {
                counterAliveCells += row
                    .Where(x => x > 0)
                    .Count();

                sumAliveCells += row
                    .Where(x => x > 0)
                    .Sum();
            }

            Console.WriteLine($"Alive cells: {counterAliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static void GetTheNewValues(int rowBomb, int colBomb, int sizeMatrix, int valueBomb, int[][] matrix)
        {
            if (IsInMatrix(rowBomb - 1, colBomb - 1, sizeMatrix) && IsCellAlive(rowBomb - 1, colBomb - 1, matrix))
            {
                matrix[rowBomb - 1][colBomb - 1] -= valueBomb;
            }

            if (IsInMatrix(rowBomb - 1, colBomb, sizeMatrix) && IsCellAlive(rowBomb - 1, colBomb, matrix))
            {
                matrix[rowBomb - 1][colBomb] -= valueBomb;
            }

            if (IsInMatrix(rowBomb - 1, colBomb + 1, sizeMatrix) && IsCellAlive(rowBomb - 1, colBomb + 1, matrix))
            {
                matrix[rowBomb - 1][colBomb + 1] -= valueBomb;
            }

            if (IsInMatrix(rowBomb, colBomb - 1, sizeMatrix) && IsCellAlive(rowBomb, colBomb - 1, matrix))
            {
                matrix[rowBomb][colBomb - 1] -= valueBomb;
            }

            if (IsInMatrix(rowBomb, colBomb + 1, sizeMatrix) && IsCellAlive(rowBomb, colBomb + 1, matrix))
            {
                matrix[rowBomb][colBomb + 1] -= valueBomb;
            }

            if (IsInMatrix(rowBomb + 1, colBomb - 1, sizeMatrix) && IsCellAlive(rowBomb + 1, colBomb - 1, matrix))
            {
                matrix[rowBomb + 1][colBomb - 1] -= valueBomb;
            }

            if (IsInMatrix(rowBomb + 1, colBomb, sizeMatrix) && IsCellAlive(rowBomb + 1, colBomb, matrix))
            {
                matrix[rowBomb + 1][colBomb] -= valueBomb;
            }

            if (IsInMatrix(rowBomb + 1, colBomb + 1, sizeMatrix) && IsCellAlive(rowBomb + 1, colBomb + 1, matrix))
            {
                matrix[rowBomb + 1][colBomb + 1] -= valueBomb;
            }
        }

        static bool IsCellAlive(int row, int col, int[][] matrix)
        {
            bool isAlive = matrix[row][col] > 0;

            return isAlive;
        }

        static bool IsInMatrix(int row, int col, int sizeMatrix)
        {
            bool isValid = row >= 0 && row <= sizeMatrix - 1
                && col >= 0 && col <= sizeMatrix - 1;

            return isValid;
        }
    }
}
