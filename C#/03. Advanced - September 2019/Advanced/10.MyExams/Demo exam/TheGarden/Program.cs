using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> vegetables = new Dictionary<string, int>();

            vegetables.Add("Carrots", 0);
            vegetables.Add("Potatoes", 0);
            vegetables.Add("Lettuce", 0);

            List<char> moleElements = new List<char>();

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

            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);

                bool isValid = row >= 0 && row <= rows - 1
                        && col >= 0 && col <= matrix[row].Length - 1;

                if (!isValid)
                {
                    continue;
                }

                if (command == "Harvest")
                {
                    char currentSymbol = matrix[row][col];

                    if (currentSymbol == 'C')
                    {
                        vegetables["Carrots"]++;
                    }
                    else if (currentSymbol == 'P')
                    {
                        vegetables["Potatoes"]++;
                    }
                    else if (currentSymbol == 'L')
                    {
                        vegetables["Lettuce"]++;
                    }

                    matrix[row][col] = ' ';
                }
                else if (command == "Mole")
                {
                    if (matrix[row][col] != ' ')
                    {
                        moleElements.Add(matrix[row][col]);
                        matrix[row][col] = ' ';
                    }
                   

                    while (true)
                    {
                        string direction = elements[3];

                        if (direction == "left")
                        {
                            if (col - 2 < 0)
                            {
                                break;
                            }

                            col -= 2;
                        }
                        else if (direction == "right")
                        {
                            if (col + 2 > matrix[row].Length - 1)
                            {
                                break;
                            }

                            col += 2;
                        }
                        else if (direction == "up")
                        {
                            if (row - 2 < 0)
                            {
                                break;
                            }

                            row -= 2;
                        }
                        else if (direction == "down")
                        {
                            if (row + 2 > rows - 1)
                            {
                                break;
                            }

                            row += 2;
                        }

                        if (matrix[row][col] == ' ')
                        {
                            continue;
                        }

                        moleElements.Add(matrix[row][col]);
                        matrix[row][col] = ' ';
                    }
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            foreach (var (vege, count) in vegetables)
            {
                Console.WriteLine($"{vege}: {count}");
            }

            Console.WriteLine($"Harmed vegetables: {moleElements.Count}");
        }
    }
}
