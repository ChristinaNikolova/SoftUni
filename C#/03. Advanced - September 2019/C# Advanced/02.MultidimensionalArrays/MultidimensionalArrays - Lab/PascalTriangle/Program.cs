using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] paskal = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                paskal[row] = new long[row + 1];

                for (int col = 0; col < paskal[row].Length; col++)
                {
                    if (col == 0 || col == paskal[row].Length - 1)
                    {
                        paskal[row][col] = 1;
                        continue;
                    }

                    paskal[row][col] = paskal[row - 1][col - 1] + paskal[row - 1][col];
                }
            }

            foreach (long[] row in paskal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
