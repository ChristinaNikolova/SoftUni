using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;
        private string name;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
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

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            int index = this.data.FindIndex(x => x.Name == name);

            if (index == -1)
            {
                return false;
            }

            this.data.RemoveAt(index);

            return true;
        }

        public Salad GetHealthiestSalad()
        {
            Salad salad = this.data
                .OrderBy(x => x.GetTotalCalories())
                .FirstOrDefault();

            return salad;

        }

        public string GenerateMenu()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (Salad salad in this.data)
            {
                message.AppendLine(salad.ToString());
            }

            return message.ToString().TrimEnd();

        }
    }
}
