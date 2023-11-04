using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DefaultGainWeight = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double GainWeightValue => DefaultGainWeight;

        public override void Eat(IFood food)
        {
            string typeFood = food.GetType().Name;

            bool isValid = typeFood == "Meat";
            if (!isValid)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }

            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
