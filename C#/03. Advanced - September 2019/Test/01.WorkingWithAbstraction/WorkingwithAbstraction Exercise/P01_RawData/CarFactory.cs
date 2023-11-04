using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public static class CarFactory
    {
        public static Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Tire[] tires = new Tire[4];

            int counter = 0;

            for (int j = 5; j < parameters.Length; j += 2)
            {
                double pressure = double.Parse(parameters[j]);
                int age = int.Parse(parameters[j + 1]);

                Tire tire = new Tire(pressure, age);
                tires[counter] = tire;

                counter++;
            }

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            Car car = new Car(model, engine, cargo, tires);

            return car;
        }
    }
}
