using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tiresCollection = new List<Tire[]>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Tire[] tires = new Tire[4];

                int counterIndexes = 0;

                for (int i = 0; i < elements.Length; i += 2)
                {
                    int year = int.Parse(elements[i]);
                    double pressure = double.Parse(elements[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tires[counterIndexes] = tire;

                    counterIndexes++;
                }

                tiresCollection.Add(tires);
            }

            List<Engine> enginesCollection = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int horsePower = int.Parse(elements[0]);
                double cubicCapacity = double.Parse(elements[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                enginesCollection.Add(engine);
            }

            List<Car> carsCollection = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = elements[0];
                string model = elements[1];
                int year = int.Parse(elements[2]);
                double fuelQuantity = double.Parse(elements[3]);
                double fuelConsumption = double.Parse(elements[4]);
                int engineIndex = int.Parse(elements[5]);
                int tiresIndex = int.Parse(elements[6]);

                Engine engine = enginesCollection[engineIndex];
                Tire[] tires = tiresCollection[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                carsCollection.Add(car);
            }

            carsCollection = carsCollection
                .Where(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Select(y => y.Pressure).Sum() >= 9
                && x.Tires.Select(y => y.Pressure).Sum() <= 10)
                .ToList();

            double distance = 20;

            foreach (Car car in carsCollection)
            {
                car.Drive(distance);
                Console.WriteLine(car.ToString());
            }
        }
    }
}
