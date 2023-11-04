using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static IAnimal Create(string[] elements)
        {
            string typeAnimal = elements[0];
            string name = elements[1];
            double weight = double.Parse(elements[2]);

            IAnimal animal = null;

            if (typeAnimal == "Hen" || typeAnimal == "Owl")
            {
                double wingSize = double.Parse(elements[3]);

                if (typeAnimal == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else
                {
                    animal = new Owl(name, weight, wingSize);
                }
            }
            else if (typeAnimal == "Dog" || typeAnimal == "Mouse")
            {
                string livingRegion = elements[3];

                if (typeAnimal == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
            }
            else if (typeAnimal == "Cat" || typeAnimal == "Tiger")
            {
                string livingRegion = elements[3];
                string breed = elements[4];

                if (typeAnimal == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
            }

            return animal;
        }
    }
}
