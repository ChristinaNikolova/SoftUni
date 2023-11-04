using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes.Models;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinValue = 12;
        private const int MaxValue = 90;

        private string fullName;
        private int age;
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName
        {
            get => this.fullName;
            private set
            {
                this.fullName = value;
            }
        }

        [MyRange(MinValue, MaxValue)]
        public int Age
        {
            get => this.age;
            private set
            {
                this.age = value;
            }
        }
    }
}
