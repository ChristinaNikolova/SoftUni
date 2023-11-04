using System;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[row].Contains('S'))
                {
                    GetSamsCoordinates(matrix, out playerRow, out playerCol, row);
                }
            }

            bool isNikoKilled = false;

            string commandsLine = Console.ReadLine();

            foreach (char currentCommand in commandsLine)
            {
                MoveEnemies(rows, matrix);

                if (IsSamKilled(matrix, playerRow, playerCol))
                {
                    matrix[playerRow][playerCol] = 'X';
                    break;
                }

                MoveSam(ref playerRow, ref playerCol, currentCommand);

                if (IsEnemyFound(matrix, playerRow, playerCol))
                {
                    matrix[playerRow][playerCol] = '.';
                }
                else if (matrix[playerRow].Contains('N'))
                {
                    KilledNikoladze(matrix, playerRow, playerCol);
                    isNikoKilled = true;
                    break;
                }
            }

            PrintTheOutput(matrix, playerRow, playerCol, isNikoKilled);
        }

        private static void GetSamsCoordinates(char[][] matrix, out int playerRow, out int playerCol, int row)
        {
            playerRow = row;
            playerCol = matrix[row].ToList().IndexOf('S');

            matrix[playerRow][playerCol] = '.';
        }

        private static bool IsEnemyFound(char[][] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow][playerCol] == 'b'
                                || matrix[playerRow][playerCol] == 'd';
        }

        private static bool KilledNikoladze(char[][] matrix, int playerRow, int playerCol)
        {
            bool isNikoKilled;
            int nikoCol = matrix[playerRow].ToList().IndexOf('N');

            matrix[playerRow][playerCol] = 'S';
            matrix[playerRow][nikoCol] = 'X';
            isNikoKilled = true;
            return isNikoKilled;
        }

        private static void PrintTheOutput(char[][] matrix, int playerRow, int playerCol, bool isNikoKilled)
        {
            if (isNikoKilled)
            {
                Console.WriteLine("Nikoladze killed!");
            }
            else
            {
                Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveSam(ref int playerRow, ref int playerCol, char currentCommand)
        {
            if (currentCommand == 'L')
            {
                playerCol--;
            }
            else if (currentCommand == 'R')
            {
                playerCol++;
            }
            else if (currentCommand == 'U')
            {
                playerRow--;
            }
            else if (currentCommand == 'D')
            {
                playerRow++;
            }
        }

        private static bool IsSamKilled(char[][] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow].Contains('b') && playerCol > matrix[playerRow].ToList().IndexOf('b')
                                || matrix[playerRow].Contains('d') && playerCol < matrix[playerRow].ToList().IndexOf('d');
        }

        private static void MoveEnemies(int rows, char[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row].Contains('b'))
                {
                    int enemyCol = matrix[row].ToList().IndexOf('b');

                    if (enemyCol + 1 <= matrix[row].Length - 1)
                    {
                        matrix[row][enemyCol] = '.';
                        matrix[row][enemyCol + 1] = 'b';
                    }
                    else
                    {
                        matrix[row][enemyCol] = 'd';
                    }
                }
                else if (matrix[row].Contains('d'))
                {
                    int enemyCol = matrix[row].ToList().IndexOf('d');

                    if (enemyCol - 1 >= 0)
                    {
                        matrix[row][enemyCol] = '.';
                        matrix[row][enemyCol - 1] = 'd';
                    }
                    else
                    {
                        matrix[row][enemyCol] = 'b';
                    }
                }
            }
        }
    }
}
