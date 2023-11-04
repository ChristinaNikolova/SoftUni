using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Set_Cover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> universe = new List<int> { 1, 2, 3, 4, 5 };
            int[][] sets = new[]
            {
                new[] { 4 },
                new[] { 1 },
                new[] { 2, 4 },
                new[] { 5 },
                new[] { 3 },
            };

            //List<int> universe = new List<int> { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            //int[][] sets = new[]
            //{
            //    new[] { 20 },
            //    new[] { 1, 5, 20, 30 },
            //    new[] { 3, 7, 20, 30, 40 },
            //    new[] { 9, 30 },
            //    new[] { 11, 20, 30, 40 },
            //    new[] { 3, 7, 40 }
            //};

            List<int[]> setsAsList = sets
                .ToList();

            int counterSets = 0;
            StringBuilder sb = new StringBuilder();

            while (universe.Count > 0 && setsAsList.Count > 0)
            {
                List<int[]> sortedSets = setsAsList
                    .OrderByDescending(x => x.Count(y => universe.Contains(y)))
                    .ToList();

                int[] currentSet = sortedSets[0];
                sortedSets.RemoveAt(0);
                counterSets++;
                sb.AppendLine(string.Join(", ", currentSet));

                for (int i = 0; i < universe.Count; i++)
                {
                    if (currentSet.Contains(universe[i]))
                    {
                        universe.RemoveAt(i);
                        i--;
                    }
                }
            }

            Console.WriteLine($"Sets to take ({counterSets}):");
            Console.WriteLine(sb.ToString());
        }
    }
}
