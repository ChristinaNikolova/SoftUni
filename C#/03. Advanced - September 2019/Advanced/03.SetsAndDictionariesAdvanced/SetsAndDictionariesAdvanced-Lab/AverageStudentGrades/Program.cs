using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsAndGrades = new Dictionary<string, List<double>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string studentName = elements[0];
                double currentGrade = double.Parse(elements[1]);

                bool isAdded = studentsAndGrades.ContainsKey(studentName);
                if (!isAdded)
                {
                    studentsAndGrades.Add(studentName, new List<double>());
                }

                studentsAndGrades[studentName].Add(currentGrade);
            }

            bool areAny = studentsAndGrades.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, studentsAndGrades
                    .Select(x=>$"{x.Key} -> {string.Join(" ", x.Value.Select(y=>y.ToString("F2")))} (avg: {x.Value.Average():F2})")));
            }
        }
    }
}
