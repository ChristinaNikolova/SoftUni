using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            this.elements = new List<T>();
        }

        public void Push(params T[] elements)
        {
            this.elements.AddRange(elements);
        }

        public void Pop()
        {
            bool areAny = this.elements.Any();
            if (!areAny)
            {
                throw new ArgumentException("No elements");
            }

            int lastIndex = this.elements.Count - 1;

            this.elements.RemoveAt(lastIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
