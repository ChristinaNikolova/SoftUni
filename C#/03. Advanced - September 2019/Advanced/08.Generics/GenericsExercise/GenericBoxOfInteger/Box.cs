using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.Element = element;
        }

        public T Element
        {
            get
            {
                return this.element;
            }
            private set
            {
                this.element = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Element.GetType()}: {this.Element}";
        }
    }
}
