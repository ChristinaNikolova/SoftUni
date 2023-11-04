using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWinner = false;

            int[] matrixProps = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            char[][] matrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                bool isPlayerFound = matrix[row].Contains('P');
                if (isPlayerFound)
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 'P');

                    matrix[playerRow][playerCol] = '.';
                }
            }

            string commandLine = Console.ReadLine();

            int winnerRow = 0;
            int winnerCol = 0;

            for (int i = 0; i < commandLine.Length; i++)
            {
                winnerRow = playerRow;
                winnerCol = playerCol;

                char currentCommand = commandLine[i];

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

                matrix = GetTheNewMatrix(matrix, rows, cols);

                bool isPlayerInMatrix = playerRow >= 0 && playerRow <= rows - 1
                    && playerCol >= 0 && playerCol <= cols - 1;

                if (isPlayerInMatrix)
                {
                    bool isDead = matrix[playerRow][playerCol] == 'B';
                    if (isDead)
                    {
                        break;
                    }
                }
                else
                {
                    isWinner = true;
                    break;
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

            if (isWinner)
            {
                Console.WriteLine($"won: {winnerRow} {winnerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static char[][] GetTheNewMatrix(char[][] matrix, int rows, int cols)
        {
            char[][] secondMatrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                secondMatrix[row] = (char[])matrix[row].Clone();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isBunny = matrix[row][col] == 'B';
                    if (isBunny)
                    {
                        if (col - 1 >= 0)
                        {
                            secondMatrix[row][col - 1] = 'B';
                        }

                        if (col + 1 <= cols - 1)
                        {
                            secondMatrix[row][col + 1] = 'B';
                        }

                        if (row - 1 >= 0)
                        {
                            secondMatrix[row - 1][col] = 'B';
                        }

                        if (row + 1 <= rows - 1)
                        {
                            secondMatrix[row + 1][col] = 'B';
                        }
                    }
                }
            }

            return secondMatrix;
        }
    }
}
