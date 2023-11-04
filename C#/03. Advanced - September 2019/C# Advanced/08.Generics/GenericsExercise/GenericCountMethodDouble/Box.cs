using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T>
         where T : IComparable<T>
    {
        public int GetTheCountOfTheGreatherElements(List<T> elements, T elementToCompare)
        {
            int counterGreatherElements = 0;

            foreach (T element in elements)
            {
                int result = element.CompareTo(elementToCompare);
                bool isGreather = result == 1;
                if (isGreather)
                {
                    counterGreatherElements++;
                }
            }

            return counterGreatherElements;
        }
    }
}
