using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        private string name;
        private int calories;

        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

                this.name = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {

                this.calories = value;
            }
        }

        public override string ToString()
        {
            return $" - {this.Name} have {this.Calories} calories";
        }
    }
}
