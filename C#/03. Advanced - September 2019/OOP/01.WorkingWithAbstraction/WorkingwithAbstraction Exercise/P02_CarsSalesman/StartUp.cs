using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                GetTheEngineCollection(engines);
            }

            List<Car> cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                GetTheCarCollection(engines, cars);
            }

            PrintTheCarCollection(cars);
        }

        private static void PrintTheCarCollection(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void GetTheCarCollection(List<Engine> engines, List<Car> cars)
        {
            string[] elementsCar = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            Car car = CarFactory.CreateCar(engines, elementsCar);

            cars.Add(car);
        }

        private static void GetTheEngineCollection(List<Engine> engines)
        {
            string[] elementsEngine = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            Engine engine = EngineFactory.CreateEngine(elementsEngine);

            engines.Add(engine);
        }
    }

}
