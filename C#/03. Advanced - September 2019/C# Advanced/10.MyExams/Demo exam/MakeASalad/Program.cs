using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> salads = new List<int>();

            Dictionary<string, int> vegetablesAndCalories = new Dictionary<string, int>();

            vegetablesAndCalories.Add("tomato", 80);
            vegetablesAndCalories.Add("carrot", 136);
            vegetablesAndCalories.Add("lettuce", 109);
            vegetablesAndCalories.Add("potato", 215);

            string[] vegetablesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> vegetables = new Queue<string>(vegetablesInput);

            int[] caloriesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> calories = new Stack<int>(caloriesInput);
            Stack<int> originalCalories = new Stack<int>(caloriesInput);

            while (vegetables.Any() && calories.Any())
            {
                string currentVegetable = vegetables.Dequeue();
                int currentCalories = calories.Peek();

                if (!vegetablesAndCalories.ContainsKey(currentVegetable))
                {
                    continue;
                }

                int caloriesCurrentVegetable = vegetablesAndCalories[currentVegetable];

                if (currentCalories < caloriesCurrentVegetable)
                {
                    salads.Add(originalCalories.Pop());
                    calories.Pop();
                    continue;
                }

                currentCalories -= caloriesCurrentVegetable;

                if (currentCalories == 0)
                {
                    calories.Pop();
                    salads.Add(originalCalories.Pop());
                }
                else
                {
                    calories.Pop();
                    calories.Push(currentCalories);
                }
            }

            if (calories.Any() && calories.Peek()!=originalCalories.Peek())
            {
                calories.Pop();
                salads.Add(originalCalories.Pop());
            }

            if (salads.Any())
            {
                Console.WriteLine(string.Join(" ", salads));
            }

            if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }
            else if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}