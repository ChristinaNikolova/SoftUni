using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasToPrint = true;

            int sizeMatrix = int.Parse(Console.ReadLine());

            string[] commandsLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[][] matrix = new char[sizeMatrix][];

            int playerRow = 0;
            int playerCol = 0;

            int counterCoals = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                bool isPlayerFound = matrix[row].Contains('s');
                if (isPlayerFound)
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 's');

                    matrix[playerRow][playerCol] = '*';
                }

                counterCoals += matrix[row]
                    .Where(x => x == 'c')
                    .Count();
            }

            for (int i = 0; i < commandsLine.Length; i++)
            {
                string currentCommand = commandsLine[i];

                if (currentCommand == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        continue;
                    }

                    playerCol--;
                }
                else if (currentCommand == "right")
                {
                    if (playerCol + 1 > sizeMatrix - 1)
                    {
                        continue;
                    }

                    playerCol++;
                }
                else if (currentCommand == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        continue;
                    }

                    playerRow--;
                }
                else if (currentCommand == "down")
                {
                    if (playerRow + 1 > sizeMatrix - 1)
                    {
                        continue;
                    }

                    playerRow++;
                }

                if (matrix[playerRow][playerCol] == 'c')
                {
                    counterCoals--;
                    matrix[playerRow][playerCol] = '*';

                    bool isSuccess = counterCoals == 0;
                    if (isSuccess)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        hasToPrint = false;
                        break;
                    }
                }
                else if (matrix[playerRow][playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    hasToPrint = false;
                    break;
                }
            }

            if (hasToPrint)
            {
                Console.WriteLine($"{counterCoals} coals left. ({playerRow}, {playerCol})");
            }
        }
    }
}

