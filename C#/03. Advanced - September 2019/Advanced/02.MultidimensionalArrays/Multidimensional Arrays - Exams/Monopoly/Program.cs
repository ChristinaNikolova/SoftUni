using System;
using System.Linq;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalMoney = 50;

            int counterTurns = 0;
            int counterHotels = 0;

            int[] matrixProps = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixProps[0];
            int cols = matrixProps[1];

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();
            }

            for (int row = 0; row < rows; row++)
            {
                int currentCol = 0;

                for (int col = 0; col < cols; col++)
                {
                    bool isRowEven = row % 2 == 0;
                    if (isRowEven)
                    {
                        currentCol = col;
                    }
                    else
                    {
                        currentCol = cols - 1 - col;
                    }

                    if (matrix[row][currentCol] == 'H')
                    {
                        int spendMoney = totalMoney;
                        totalMoney = 0;
                        counterHotels++;

                        Console.WriteLine($"Bought a hotel for {spendMoney}. Total hotels: {counterHotels}.");
                    }
                    else if (matrix[row][currentCol] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {counterTurns}.");

                        counterTurns += 2;
                        totalMoney += 2 * 10 * counterHotels;
                    }
                    else if (matrix[row][currentCol] == 'S')
                    {
                        int product = (row + 1) * (currentCol + 1);
                        int spendMoney = Math.Min(product, totalMoney);

                        totalMoney -= spendMoney;

                        Console.WriteLine($"Spent {spendMoney} money at the shop.");
                    }

                    counterTurns++;
                    totalMoney += 10 * counterHotels;
                }
            }

            Console.WriteLine($"Turns {counterTurns}");
            Console.WriteLine($"Money {totalMoney}");
        }
    }
}
