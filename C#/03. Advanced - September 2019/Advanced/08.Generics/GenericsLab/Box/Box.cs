using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            int lastIndex = this.elements.Count - 1;
            T elementToRemove = this.elements[lastIndex];

            this.elements.RemoveAt(lastIndex);

            return elementToRemove;
        }
    }
}
