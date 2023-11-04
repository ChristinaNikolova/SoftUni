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
            int counterCars = 0;
            bool isCrash = false;

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
                            counterCars++;
                        }
                        else
                        {
                            int leftParts = currentCar.Length - leftSeconds;

                            bool isSafe = leftParts <= durationYellowLight;
                            if (isSafe)
                            {
                                cars.Dequeue();
                                counterCars++;
                            }
                            else
                            {
                                int safeParts = leftSeconds + durationYellowLight;
                                char symbolToCrash = currentCar[safeParts];

                                isCrash = true;

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {symbolToCrash}.");
                            }

                            break;
                        }
                    }
                }
                else
                {
                    string currentCar = input;
                    cars.Enqueue(currentCar);
                }
            }

            if (!isCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counterCars} total cars passed the crossroads.");
            }
        }
    }
}
