using System;
using System.Collections.Generic;
using System.Text;

namespace RandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, this.Count);

            string randomElement = this[randomIndex];
            this.RemoveAt(randomIndex);

            return randomElement;
        }
    }
}
