using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            for (int row = 0; row < sizeMatrix; row++)
            {
                char[] elementsCurrentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = elementsCurrentRow[col];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    char currentSymbol = matrix[row, col];

                    bool areEqaul = currentSymbol == searchedSymbol;
                    if (areEqaul)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchedSymbol} does not occur in the matrix ");
        }
    }
}
