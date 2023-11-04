using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private List<Person> data;

        public Repository()
        {
            this.data = new List<Person>();
        }

        public int Count => this.data.Count;

        public void Add(Person person)
        {
            this.data.Add(person);
        }

        public Person Get(int id)
        {
            Person personToReturn = this.data[id];

            return personToReturn;
        }

        public bool Update(int id, Person newPerson)
        {
            bool isIdValid = id >= 0 && id <= this.data.Count - 1;
            if (!isIdValid)
            {
                return false;
            }

            this.data.RemoveAt(id);
            this.data.Insert(id, newPerson);

            return true;
        }

        public bool Delete(int id)
        {
            bool isIdValid = id >= 0 && id <= this.data.Count - 1;
            if (!isIdValid)
            {
                return false;
            }

            this.data.RemoveAt(id);

            return true;
        }
    }
}
