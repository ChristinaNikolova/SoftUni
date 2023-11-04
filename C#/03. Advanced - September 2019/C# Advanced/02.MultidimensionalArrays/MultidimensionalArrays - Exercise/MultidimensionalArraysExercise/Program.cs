using System;
using System.Linq;

namespace MultidimensionalArraysExercise
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

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            int startRowFirstDiagonal = 0;
            int startColFirstDiagonal = 0;

            int startRowSecondDiagonal = 0;
            int startColSecondDiagonal = sizeMatrix - 1;

            for (int i = 0; i < sizeMatrix; i++)
            {
                sumFirstDiagonal += matrix[startRowFirstDiagonal, startColFirstDiagonal];
                sumSecondDiagonal += matrix[startRowSecondDiagonal, startColSecondDiagonal];

                startRowFirstDiagonal++;
                startColFirstDiagonal++;
                startRowSecondDiagonal++;
                startColSecondDiagonal--;
            }

            int diff = Math.Abs(sumFirstDiagonal - sumSecondDiagonal);

            Console.WriteLine(diff);
        }
    }
}
