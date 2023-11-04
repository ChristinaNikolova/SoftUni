using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                Car car = CarFactory.CreateCar(parameters);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            cars = GetTheFilteredColetion(cars, command);
            PrintTheCollection(cars);
        }

        private static void PrintTheCollection(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static List<Car> GetTheFilteredColetion(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                cars = cars
                    .Where(x => x.Cargo.CargoType == "fragile" &&
                    x.Tires.Any(y => y.Pressure < 1))
                    .ToList();
            }
            else if (command == "flamable")
            {
                cars = cars
                    .Where(x => x.Cargo.CargoType == "flamable"
                    && x.Engine.EnginePower > 250)
                    .ToList();
            }

            return cars;
        }
    }
}
