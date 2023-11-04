using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public Box(List<T> elements)
        {
            this.elements = elements;
        }

        public int GetTheCountOfTheGreatherElements(T elementToCompare)
        {
            int counterGreatherElements = 0;

            foreach (T element in this.elements)
            {
               int result = element.CompareTo(elementToCompare);

                bool isGreater = result == 1;
                if (isGreater)
                {
                    counterGreatherElements++;
                }
            }

            return counterGreatherElements;
        }
    }
}
