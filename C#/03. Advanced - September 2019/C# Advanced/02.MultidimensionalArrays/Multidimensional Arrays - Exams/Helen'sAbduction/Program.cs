using System;
using System.Linq;

namespace Helen_sAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energyParis = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int parisRow = 0;
            int parisCol = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                bool isParisFound = matrix[row].Contains('P');
                if (isParisFound)
                {
                    parisRow = row;
                    parisCol = matrix[row].ToList().IndexOf('P');

                    matrix[parisRow][parisCol] = '-';
                }
            }

            bool isHeleneFound = false;
            bool isParisDead = false;

            while (!isHeleneFound && !isParisDead)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                int enemyRow = int.Parse(elements[1]);
                int enemyCol = int.Parse(elements[2]);

                matrix[enemyRow][enemyCol] = 'S';

                energyParis -= 1;

                if (command == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol--;
                    }
                }
                else if (command == "right")
                {
                    if (parisCol + 1 <= matrix[parisRow].Length - 1)
                    {
                        parisCol++;
                    }
                }
                else if (command == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }
                }
                else if (command == "down")
                {
                    if (parisRow + 1 <= rows - 1)
                    {
                        parisRow++;
                    }
                }

                if (matrix[parisRow][parisCol] == 'H')
                {
                    matrix[parisRow][parisCol] = '-';
                    isHeleneFound = true;
                    continue;
                }

                bool isEnergy = energyParis > 0;
                if (!isEnergy)
                {
                    matrix[parisRow][parisCol] = 'X';
                    isParisDead = true;
                    continue;
                }

                if (matrix[parisRow][parisCol] == 'S')
                {
                    energyParis -= 2;

                    if (energyParis > 0)
                    {
                        matrix[parisRow][parisCol] = '-';
                    }
                    else
                    {
                        matrix[parisRow][parisCol] = 'X';
                        isParisDead = true;
                        continue;
                    }
                }
            }

            if (isHeleneFound)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energyParis}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
