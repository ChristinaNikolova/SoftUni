using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public static class CarFactory
    {
        public static Car CreateCar(List<Engine> engines, params string[] elementsCar)
        {
            string model = elementsCar[0];
            string engineModel = elementsCar[1];

            Engine engine = engines
                .FirstOrDefault(x => x.Model == engineModel);

            Car car = null;

            if (elementsCar.Length == 4)
            {
                int weight = int.Parse(elementsCar[2]);
                string color = elementsCar[3];

                car = new Car(model, engine, weight, color);
            }
            else if (elementsCar.Length == 3)
            {
                string elementToCheck = elementsCar[2];

                if (char.IsDigit(elementToCheck[0]))
                {
                    int weight = int.Parse(elementToCheck);

                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = elementToCheck;

                    car = new Car(model, engine, color);
                }
            }
            else if (elementsCar.Length == 2)
            {
                car = new Car(model, engine);
            }

            return car;
        }
    }
}
