using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double DefaultGainWeight = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double GainWeightValue => DefaultGainWeight;

        public override void Eat(IFood food)
        {
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
