using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int counterPassedCars = 0;

            int numberCarsPerGreen = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    int countToPass = Math.Min(cars.Count, numberCarsPerGreen);

                    for (int i = 0; i < countToPass; i++)
                    {
                        string carToPass = cars.Dequeue();

                        Console.WriteLine($"{carToPass} passed!");
                        counterPassedCars++;
                    }

                    continue;
                }

                string currentCar = input;
                cars.Enqueue(currentCar);
            }

            Console.WriteLine($"{counterPassedCars} cars passed the crossroads.");
        }
    }
}
