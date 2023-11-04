using System;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = elements[0];
                string country = elements[1];
                int age = int.Parse(elements[2]);

                Citizen citizen = new Citizen(name, country, age);

                IResident resident = citizen as IResident;
                IPerson person = citizen as IPerson;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
