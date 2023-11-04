using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double DefaultGainWeight = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
