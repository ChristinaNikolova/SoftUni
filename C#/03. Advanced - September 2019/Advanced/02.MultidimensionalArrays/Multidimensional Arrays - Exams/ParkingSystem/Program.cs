using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
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

            Dictionary<int, List<int>> takenSpots = new Dictionary<int, List<int>>();

            for (int row = 0; row < rows; row++)
            {
                takenSpots.Add(row, new List<int>());
                takenSpots[row].Add(0);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                int[] elements = input
                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();

                int entryRow = elements[0];
                int targetRow = elements[1];
                int targetCol = elements[2];

                if (!takenSpots[targetRow].Contains(targetCol))
                {
                    takenSpots[targetRow].Add(targetCol);

                    int steps = Math.Abs(entryRow - targetRow) + targetCol + 1;

                    Console.WriteLine(steps);
                }
                else if (takenSpots[targetRow].Count == cols)
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                else
                {
                    int index = 1;

                    while (true)
                    {
                        int currentCol = targetCol - index;

                        if (!takenSpots[targetRow].Contains(currentCol) && currentCol > 0)
                        {
                            takenSpots[targetRow].Add(currentCol);

                            int steps = Math.Abs(entryRow - targetRow) + currentCol + 1;

                            Console.WriteLine(steps);

                            break;
                        }

                        currentCol = targetCol + index;

                        if (!takenSpots[targetRow].Contains(currentCol) && currentCol <= cols - 1)
                        {
                            takenSpots[targetRow].Add(currentCol);

                            int steps = Math.Abs(entryRow - targetRow) + currentCol + 1;

                            Console.WriteLine(steps);

                            break;
                        }

                        index++;
                    }
                }
            }
        }
    }
}
