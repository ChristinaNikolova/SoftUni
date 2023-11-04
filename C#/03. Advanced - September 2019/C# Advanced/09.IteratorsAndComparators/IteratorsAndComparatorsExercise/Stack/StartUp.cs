using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" ", 2)
                    .ToArray();

                string command = elements[0];

                if (command == "Push")
                {
                    int[] elementsToAdd = elements[1]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(elementsToAdd);
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int number in stack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
