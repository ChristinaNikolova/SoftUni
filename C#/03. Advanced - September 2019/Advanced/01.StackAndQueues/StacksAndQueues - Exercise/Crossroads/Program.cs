using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            bool isCrash = false;
            int counterPassedCars = 0;

            int durationGreenLight = int.Parse(Console.ReadLine());
            int durationYellowLight = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END" && !isCrash)
            {
                if (input == "green")
                {
                    int leftSeconds = durationGreenLight;

                    while (cars.Any() && leftSeconds > 0)
                    {
                        string currentCar = cars.Peek();

                        bool isTimeEnough = currentCar.Length <= leftSeconds;
                        if (isTimeEnough)
                        {
                            leftSeconds -= currentCar.Length;
                            cars.Dequeue();
                            counterPassedCars++;
                        }
                        else
                        {
                            int leftParts = currentCar.Length - leftSeconds;

                            bool isSafe = leftParts <= durationYellowLight;
                            if (isSafe)
                            {
                                cars.Dequeue();
                                counterPassedCars++;
                            }
                            else
                            {
                                int passedSymbols = leftSeconds + durationYellowLight;
                                char symbolToCrash = currentCar[passedSymbols];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {symbolToCrash}.");

                                isCrash = true;
                            }

                            break;
                        }
                    }
                }
                else
                {
                    string carToAdd = input;
                    cars.Enqueue(carToAdd);
                }
            }

            if (!isCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counterPassedCars} total cars passed the crossroads.");
            }
        }
    }
}
