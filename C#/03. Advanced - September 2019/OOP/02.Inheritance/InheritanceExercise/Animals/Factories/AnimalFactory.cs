using Animals.Animals;
using Animals.Animals.Cats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Factories
{
    public static class AnimalFactory
    {
        public static Animal Create(string animalType, string[] elements)
        {
            string name = elements[0];
            int age = int.Parse(elements[1]);
            string gender = elements[2];

            Animal animal = null;

            if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Kitten")
            {
                if (gender != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }

                animal = new Kitten(name, age);
            }
            else if (animalType == "Tomcat")
            {
                if (gender != "Male")
                {
                    throw new ArgumentException("Invalid input!");
                }

                animal = new Tomcat(name, age);
            }

            return animal;
        }
    }
}
