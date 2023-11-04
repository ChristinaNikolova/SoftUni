using System;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder message = new StringBuilder();
            message.Append(text);

            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = matrix[row].ToList().IndexOf('P');

                    matrix[playerRow][playerCol] = '-';
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string command = input;

                if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;

                        if (char.IsLetter(matrix[playerRow][playerCol]))
                        {
                            char letter = matrix[playerRow][playerCol];
                            message.Append(letter);

                            matrix[playerRow][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (message.Length > 0)
                        {
                            message.Length--;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 <= sizeMatrix - 1)
                    {
                        playerCol++;

                        if (char.IsLetter(matrix[playerRow][playerCol]))
                        {
                            char letter = matrix[playerRow][playerCol];
                            message.Append(letter);

                            matrix[playerRow][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (message.Length > 0)
                        {
                            message.Length--;
                        }
                    }
                }
                else if (command == "up")
                {

                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;

                        if (char.IsLetter(matrix[playerRow][playerCol]))
                        {
                            char letter = matrix[playerRow][playerCol];
                            message.Append(letter);

                            matrix[playerRow][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (message.Length > 0)
                        {
                            message.Length--;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 <= sizeMatrix - 1)
                    {
                        playerRow++;

                        if (char.IsLetter(matrix[playerRow][playerCol]))
                        {
                            char letter = matrix[playerRow][playerCol];
                            message.Append(letter);

                            matrix[playerRow][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (message.Length > 0)
                        {
                            message.Length--;
                        }
                    }
                }
            }

            matrix[playerRow][playerCol] = 'P';

            Console.WriteLine(message);

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
