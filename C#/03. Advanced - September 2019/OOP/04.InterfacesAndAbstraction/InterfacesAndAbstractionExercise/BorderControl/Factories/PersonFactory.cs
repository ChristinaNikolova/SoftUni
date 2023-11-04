using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Factories
{
    public static class PersonFactory
    {
        public static Person Create(string[] elements)
        {
            string name = elements[0];
            int age = int.Parse(elements[1]);

            Person person = null;

            if (elements.Length == 4)
            {
                string id = elements[2];
                string birthdate = elements[3];

                person = new Citizen(name, age, id, birthdate);
            }
            else if (elements.Length == 3)
            {
                string group = elements[2];

                person = new Rebel(name, age, group);
            }

            return person;
        }
    }
}
