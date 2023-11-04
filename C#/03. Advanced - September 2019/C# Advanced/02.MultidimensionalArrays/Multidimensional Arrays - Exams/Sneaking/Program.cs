using System;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                bool isSamFound = matrix[row].Contains('S');
                if (isSamFound)
                {
                    playerRow = row;
                    playerCol = matrix[row].ToList().IndexOf('S');

                    matrix[playerRow][playerCol] = '.';
                }
            }

            bool isSuccess = false;

            string commandLine = Console.ReadLine();

            foreach (char currentCommand in commandLine)
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

                bool isSamKilled = matrix[playerRow].Contains('b') && playerCol > matrix[playerRow].ToList().IndexOf('b')
                    || matrix[playerRow].Contains('d') && playerCol < matrix[playerRow].ToList().IndexOf('d');

                if (isSamKilled)
                {
                    matrix[playerRow][playerCol] = 'X';
                    break;
                }

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
                else if (currentCommand == 'W')
                {
                    continue;
                }

                if (matrix[playerRow][playerCol] == 'b' || matrix[playerRow][playerCol] == 'd')
                {
                    matrix[playerRow][playerCol] = '.';
                }
                else if (matrix[playerRow].Contains('N'))
                {
                    int nikoCol = matrix[playerRow].ToList().IndexOf('N');

                    matrix[playerRow][nikoCol] = 'X';
                    matrix[playerRow][playerCol] = 'S';

                    isSuccess = true;
                    break;
                }
            }

            if (isSuccess)
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
    }
}
