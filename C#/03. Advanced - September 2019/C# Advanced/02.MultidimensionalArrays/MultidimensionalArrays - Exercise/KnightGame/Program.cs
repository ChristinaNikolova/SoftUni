using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();
            }

            int counterRemovedKnights = 0;

            bool canAttack = true;

            while (canAttack)
            {
                int maxAttacked = 0;
                int maxRow = 0;
                int maxCol = 0;

                for (int row = 0; row < sizeMatrix; row++)
                {
                    for (int col = 0; col < sizeMatrix; col++)
                    {
                        char currentSymbol = matrix[row][col];

                        bool isKnight = currentSymbol == 'K';
                        if (isKnight)
                        {
                            int countAtteckedKnights = CountAttackedKnights(sizeMatrix, matrix, row, col);

                            bool isMaxAttacked = countAtteckedKnights > maxAttacked;
                            if (isMaxAttacked)
                            {
                                maxAttacked = countAtteckedKnights;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                bool isFound = maxAttacked > 0;
                if (isFound)
                {
                    matrix[maxRow][maxCol] = '0';
                    counterRemovedKnights++;
                }
                else
                {
                    canAttack = false;
                }
            }

            Console.WriteLine(counterRemovedKnights);
        }

        private static int CountAttackedKnights(int sizeMatrix, char[][] matrix, int row, int col)
        {
            int countAtteckedKnights = 0;

            if (IsInMatrix(row - 2, col - 1, sizeMatrix) && IsKnight(row - 2, col - 1, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row - 2, col + 1, sizeMatrix) && IsKnight(row - 2, col + 1, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row + 2, col - 1, sizeMatrix) && IsKnight(row + 2, col - 1, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row + 2, col + 1, sizeMatrix) && IsKnight(row + 2, col + 1, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row - 1, col - 2, sizeMatrix) && IsKnight(row - 1, col - 2, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row - 1, col + 2, sizeMatrix) && IsKnight(row - 1, col + 2, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row + 1, col - 2, sizeMatrix) && IsKnight(row + 1, col - 2, matrix))
            {
                countAtteckedKnights++;
            }

            if (IsInMatrix(row + 1, col + 2, sizeMatrix) && IsKnight(row + 1, col + 2, matrix))
            {
                countAtteckedKnights++;
            }

            return countAtteckedKnights;
        }

        static bool IsKnight(int row, int col, char[][] matrix)
        {
            bool isKnight = matrix[row][col] == 'K';

            return isKnight;
        }

        static bool IsInMatrix(int row, int col, int sizeMatrix)
        {
            bool isValid = row >= 0 && row <= sizeMatrix - 1
                && col >= 0 && col <= sizeMatrix - 1;

            return isValid;
        }
    }
}
