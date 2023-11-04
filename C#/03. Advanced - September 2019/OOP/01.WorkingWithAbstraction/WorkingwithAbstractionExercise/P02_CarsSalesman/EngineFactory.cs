using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public static class EngineFactory
    {
        public static Engine CreateEngine(params string[] elementsEngine)
        {
            string model = elementsEngine[0];
            int power = int.Parse(elementsEngine[1]);

            Engine engine = null;

            if (elementsEngine.Length == 4)
            {
                int displacement = int.Parse(elementsEngine[2]);
                string efficiency = elementsEngine[3];

                engine = new Engine(model, power, displacement, efficiency);
            }
            else if (elementsEngine.Length == 3)
            {
                string elementToCheck = elementsEngine[2];

                if (char.IsDigit(elementToCheck[0]))
                {
                    int displacement = int.Parse(elementToCheck);

                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = elementToCheck;

                    engine = new Engine(model, power, efficiency);
                }
            }
            else if (elementsEngine.Length == 2)
            {
                engine = new Engine(model, power);
            }

            return engine;
        }
    }
}
