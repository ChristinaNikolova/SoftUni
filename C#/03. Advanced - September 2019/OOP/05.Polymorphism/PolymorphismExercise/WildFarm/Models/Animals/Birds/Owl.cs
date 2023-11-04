using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double DefaultGainWeight = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
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
            return "Hoot Hoot";
        }
    }
}
