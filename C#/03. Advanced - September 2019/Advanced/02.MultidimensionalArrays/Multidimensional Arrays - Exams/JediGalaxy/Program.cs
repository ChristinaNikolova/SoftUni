using System;
using System.Linq;

namespace JediGalaxy
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

            int[,] matrix = new int[rows, cols];

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }

            long sumPowerStars = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoProps = input
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                int ivoRow = ivoProps[0];
                int ivoCol = ivoProps[1];

                int[] evilProps = Console.ReadLine()
                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();

                int evilRow = evilProps[0];
                int evilCol = evilProps[1];

                while (evilRow >= 0)
                {
                    if (evilRow <= rows - 1 && evilCol >= 0 && evilCol <= cols - 1)
                    {
                        matrix[evilRow, evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0)
                {
                    if (ivoRow <= rows - 1 && ivoCol >= 0 && ivoCol <= cols - 1)
                    {
                        sumPowerStars += matrix[ivoRow, ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }
            }

            Console.WriteLine(sumPowerStars);
        }
    }
}
