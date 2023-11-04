using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Factories
{
    public static class BirthtableFactory
    {
        public static IBirthable Create(string[] elements)
        {
            IBirthable birthable = null;

            if (elements.Length == 5)
            {
                string name = elements[1];
                int age = int.Parse(elements[2]);
                string id = elements[3];
                string birthdate = elements[4];

                birthable = new Citizen(name, age, id, birthdate);
            }
            else if (elements.Length == 3 && elements.Contains("Pet"))
            {
                string name = elements[1];
                string birthdate = elements[2];

                birthable = new Pet(name, birthdate);
            }
            else
            {
                throw new Exception();
            }

            return birthable;
        }
    }
}
