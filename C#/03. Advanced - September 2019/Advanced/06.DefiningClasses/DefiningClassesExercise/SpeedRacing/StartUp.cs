using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = elements[0];
                double fuelAmount = double.Parse(elements[1]);
                double fuelConsumptionForOneKm = double.Parse(elements[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForOneKm);
                cars.Add(car);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                string carModel = elements[1];
                double distance = double.Parse(elements[2]);

                bool isCarValid = cars.Any(x => x.Model == carModel);
                if (!isCarValid)
                {
                    continue;
                }

                Car currentCar = cars
                    .Where(x => x.Model == carModel)
                    .FirstOrDefault();

                currentCar.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
