using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];

            for (int row = 0; row < sizeMatrix; row++)
            {
                int[] elementsCurrentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = elementsCurrentRow[col];
                }
            }

            int sumPrimiaryDiagonal = 0;
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < sizeMatrix; i++)
            {
                sumPrimiaryDiagonal += matrix[startRow, startCol];

                startRow++;
                startCol++;
            }

            Console.WriteLine(sumPrimiaryDiagonal);
        }
    }
}
