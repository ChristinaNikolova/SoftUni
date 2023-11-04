using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int currentIndex;

        public ListyIterator(params T[] elements)
        {
            this.elements = elements.ToList();
            this.currentIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool HasNext()
        {
            bool hasNext = this.currentIndex + 1 <= this.elements.Count - 1;
            if (!hasNext)
            {
                return false;
            }

            return true;
        }

        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.currentIndex++;

            return true;
        }

        public void Print()
        {
            bool areAny = this.elements.Any();
            if (!areAny)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[this.currentIndex]);
        }
    }
}
