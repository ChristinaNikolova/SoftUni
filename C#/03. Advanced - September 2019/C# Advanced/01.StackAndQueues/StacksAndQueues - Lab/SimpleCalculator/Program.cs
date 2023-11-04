using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> elements = new Stack<string>(expression);

            int result = 0;

            while (elements.Any())
            {
                string currentElement = elements.Pop();

                if (currentElement == "+")
                {
                    int numberToAdd = int.Parse(elements.Pop());

                    result += numberToAdd;
                }
                else if (currentElement == "-")
                {
                    int numberToRemove = int.Parse(elements.Pop());

                    result -= numberToRemove;
                }
                else
                {
                    result = int.Parse(currentElement);
                }
            }

            Console.WriteLine(result);
        }
    }
}
