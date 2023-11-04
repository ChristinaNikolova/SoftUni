using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> halls = new Queue<string>();
            Queue<int> companies = new Queue<int>();

            int hallCapacity = int.Parse(Console.ReadLine());
            int leftCapacity = hallCapacity;

            Stack<string> inputLine = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            while (inputLine.Any())
            {
                string currentElement = inputLine.Peek();

                bool isNumber = char.IsDigit(currentElement[0]);
                if (!isNumber)
                {
                    halls.Enqueue(currentElement);
                    inputLine.Pop();
                }
                else
                {
                    int currentCompany = int.Parse(currentElement);

                    bool isHall = halls.Any();
                    if (!isHall)
                    {
                        inputLine.Pop();
                        continue;
                    }

                    bool isCapacityEnough = currentCompany <= leftCapacity;
                    if (isCapacityEnough)
                    {
                        companies.Enqueue(currentCompany);
                        leftCapacity -= currentCompany;
                        inputLine.Pop();
                    }
                    else
                    {
                        string currentHall = halls.Dequeue();

                        Console.WriteLine($"{currentHall} -> {string.Join(", ", companies)}");

                        companies.Clear();
                        leftCapacity = hallCapacity;
                    }
                }
            }
        }
    }
}
