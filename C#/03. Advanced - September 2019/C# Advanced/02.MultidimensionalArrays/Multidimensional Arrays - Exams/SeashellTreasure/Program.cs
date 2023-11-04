using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> shells = new List<char>() { 'C', 'N', 'M' };

            List<char> collectedShells = new List<char>();
            int counterStolenShells = 0;

            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Sunset")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);

                bool isPlaceValid = row >= 0 && row <= rows - 1
                    && col >= 0 && col <= matrix[row].Length - 1;

                if (!isPlaceValid)
                {
                    continue;
                }

                if (command == "Collect")
                {
                    if (!shells.Contains(matrix[row][col]))
                    {
                        continue;
                    }

                    collectedShells.Add(matrix[row][col]);
                    matrix[row][col] = '-';
                }
                else if (command == "Steal")
                {
                    string direction = elements[3];

                    if (shells.Contains(matrix[row][col]))
                    {
                        counterStolenShells++;
                        matrix[row][col] = '-';
                    }

                    if (direction == "left")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col - 1 < 0)
                            {
                                break;
                            }

                            col--;

                            if (shells.Contains(matrix[row][col]))
                            {
                                counterStolenShells++;
                                matrix[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col + 1 > matrix[row].Length - 1)
                            {
                                break;
                            }

                            col++;

                            if (shells.Contains(matrix[row][col]))
                            {
                                counterStolenShells++;
                                matrix[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "up")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row - 1 < 0)
                            {
                                break;
                            }

                            row--;

                            if (shells.Contains(matrix[row][col]))
                            {
                                counterStolenShells++;
                                matrix[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row + 1 > rows - 1)
                            {
                                break;
                            }

                            row++;

                            if (shells.Contains(matrix[row][col]))
                            {
                                counterStolenShells++;
                                matrix[row][col] = '-';
                            }
                        }
                    }
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            bool areCollectedShells = collectedShells.Any();
            if (areCollectedShells)
            {
                Console.WriteLine($"Collected seashells: {collectedShells.Count} -> {string.Join(", ", collectedShells)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedShells.Count}");
            }

            Console.WriteLine($"Stolen seashells: {counterStolenShells}");
        }
    }
}
