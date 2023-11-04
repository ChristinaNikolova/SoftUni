using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            int firstRow = 0;
            int firstCol = 0;

            int secondRow = 0;
            int secondCol = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                bool isFirstFound = matrix[row].Contains('f');
                if (isFirstFound)
                {
                    firstRow = row;
                    firstCol = matrix[row].ToList().IndexOf('f');
                }

                bool isSecondFound = matrix[row].Contains('s');
                if (isSecondFound)
                {
                    secondRow = row;
                    secondCol = matrix[row].ToList().IndexOf('s');
                }
            }

            char firstSymbol = 'f';
            char secondSymbol = 's';

            bool areBothAlive = true;

            while (areBothAlive)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstCommand = elements[0];
                string secondCommand = elements[1];

                int[] firstProps = GetTheNewMatrix(firstCommand, firstSymbol, secondSymbol, firstRow, firstCol, sizeMatrix, matrix);

                firstRow = firstProps[0];
                firstCol = firstProps[1];

                if (matrix[firstRow][firstCol] == 'x')
                {
                    areBothAlive = false;
                    continue;
                }

                int[] secondProps = GetTheNewMatrix(secondCommand, secondSymbol, firstSymbol, secondRow, secondCol, sizeMatrix, matrix);

                secondRow = secondProps[0];
                secondCol = secondProps[1];

                if (matrix[secondRow][secondCol] == 'x')
                {
                    areBothAlive = false;
                    continue;
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static int[] GetTheNewMatrix(string command, char symbol, char enemySymbol, int row, int col, int sizeMatrix, char[][] matrix)
        {
            if (command == "left")
            {
                if (col - 1 >= 0)
                {
                    col--;
                }
                else
                {
                    col = matrix[row].Length - 1;
                }
            }
            else if (command == "right")
            {
                if (col + 1 <= matrix[row].Length - 1)
                {
                    col++;
                }
                else
                {
                    col = 0;
                }
            }
            else if (command == "up")
            {
                if (row - 1 >= 0)
                {
                    row--;
                }
                else
                {
                    row = matrix.Length - 1;
                }
            }
            else if (command == "down")
            {
                if (row + 1 <= matrix.Length - 1)
                {
                    row++;
                }
                else
                {
                    row = 0;
                }
            }

            if (matrix[row][col] == enemySymbol)
            {
                matrix[row][col] = 'x';
            }
            else
            {
                matrix[row][col] = symbol;
            }

            int[] props = new int[2] { row, col };

            return props;
        }
    }
}
