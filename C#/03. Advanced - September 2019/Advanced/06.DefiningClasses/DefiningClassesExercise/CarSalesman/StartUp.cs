using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = elements[0];
                int power = int.Parse(elements[1]);

                Engine engine = null;

                if (elements.Length == 4)
                {
                    int displacement = int.Parse(elements[2]);
                    string efficiency = elements[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (elements.Length == 3)
                {
                    string checkElement = elements[2];

                    bool isDigit = char.IsDigit(checkElement[0]);
                    if (isDigit)
                    {
                        int displacement = int.Parse(checkElement);

                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = checkElement;

                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (elements.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = elements[0];
                string engineModel = elements[1];

                Engine engine = engines
                    .Where(x => x.Model == engineModel)
                    .FirstOrDefault();

                Car car = null;

                if (elements.Length == 4)
                {
                    int weight = int.Parse(elements[2]);
                    string color = elements[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (elements.Length == 3)
                {
                    string checkElement = elements[2];

                    bool isDigit = char.IsDigit(checkElement[0]);
                    if (isDigit)
                    {
                        int weight = int.Parse(checkElement);

                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = checkElement;

                        car = new Car(model, engine, color);
                    }
                }
                else if (elements.Length == 2)
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
