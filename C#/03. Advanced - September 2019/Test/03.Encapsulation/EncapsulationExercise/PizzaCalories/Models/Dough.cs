using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;
        private const int MinValueWeight = 1;
        private const int MaxValueWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> flourTypesAndModifiers;
        private Dictionary<string, double> bakingTechniquesAndModifiers;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourTypesAndModifiers = new Dictionary<string, double>();
            this.GetTheFlourTypesAndModifiers();

            this.bakingTechniquesAndModifiers = new Dictionary<string, double>();
            this.GetTheBakingTechniquesAndModifiers();

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.flourTypesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!this.bakingTechniquesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinValueWeight || value > MaxValueWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinValueWeight}..{MaxValueWeight}].");
                }

                this.weight = value;
            }
        }

        public double Calories => this.GetTheCalories();

        private double GetTheCalories()
        {
            double calories = BaseCaloriesPerGram *
                 this.Weight *
                 this.flourTypesAndModifiers[this.FlourType.ToLower()] *
                 this.bakingTechniquesAndModifiers[this.BakingTechnique.ToLower()];

            return calories;
        }

        private void GetTheFlourTypesAndModifiers()
        {
            this.flourTypesAndModifiers.Add("white", 1.5);
            this.flourTypesAndModifiers.Add("wholegrain", 1.0);
        }

        private void GetTheBakingTechniquesAndModifiers()
        {
            this.bakingTechniquesAndModifiers.Add("crispy", 0.9);
            this.bakingTechniquesAndModifiers.Add("chewy", 1.1);
            this.bakingTechniquesAndModifiers.Add("homemade", 1.0);
        }
    }
}
