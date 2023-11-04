using System;
using System.Linq;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                bool isPlayerFound = matrix[row].Contains('S');
                if (isPlayerFound)
                {
                    playerRow = row;
                    playerCol = matrix[row].ToList().IndexOf('S');

                    matrix[playerRow][playerCol] = '-';
                }
            }

            bool isLost = false;
            bool isSumCollected = false;

            int sumPowerStars = 0;

            while (!isLost && !isSumCollected)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }
                else if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }

                bool isInMatrix = playerRow >= 0 && playerRow <= sizeMatrix - 1
                    && playerCol >= 0 && playerCol <= sizeMatrix - 1;
                if (!isInMatrix)
                {
                    isLost = true;
                    continue;
                }

                if (char.IsDigit(matrix[playerRow][playerCol]))
                {
                    int currentPower = int.Parse(matrix[playerRow][playerCol].ToString());
                    sumPowerStars += currentPower;
                    matrix[playerRow][playerCol] = '-';

                    bool hasToBreak = sumPowerStars >= 50;
                    if (hasToBreak)
                    {
                        matrix[playerRow][playerCol] = 'S';
                        isSumCollected = true;
                        continue;
                    }
                }
                else if (matrix[playerRow][playerCol] == 'O')
                {
                    matrix[playerRow][playerCol] = '-';

                    for (int row = 0; row < sizeMatrix; row++)
                    {
                        bool isFound = matrix[row].Contains('O');
                        if (isFound)
                        {
                            playerRow = row;
                            playerCol = matrix[row].ToList().IndexOf('O');

                            matrix[row][playerCol] = '-';
                        }
                    }
                }
            }

            if (isSumCollected)
            {
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine($"Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {sumPowerStars}");

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
