using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public abstract class Person : IPerson, IBuyer
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
