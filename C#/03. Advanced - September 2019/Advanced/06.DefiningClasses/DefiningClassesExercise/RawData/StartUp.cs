using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                int engineSpeed = int.Parse(elements[1]);
                int enginePower = int.Parse(elements[2]);
                int cargoWeight = int.Parse(elements[3]);
                string cargoType = elements[4];

                Tire[] tires = new Tire[4];

                int counterIndexes = 0;

                for (int j = 5; j < elements.Length; j += 2)
                {
                    double pressure = double.Parse(elements[j]);
                    int age = int.Parse(elements[j + 1]);

                    Tire tire = new Tire(pressure, age);
                    tires[counterIndexes] = tire;

                    counterIndexes++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string commandToPrint = Console.ReadLine();

            if (commandToPrint == "fragile")
            {
                cars = cars
                    .Where(x => x.Cargo.CargoType == "fragile"
                    && x.Tires.Any(y => y.Pressure < 1))
                    .ToList();
            }
            else if (commandToPrint == "flamable")
            {
                cars = cars
                    .Where(x => x.Cargo.CargoType == "flamable"
                    && x.Engine.EnginePower > 250)
                    .ToList();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
